using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Environment;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FluxoDeCaixa.Infrastructure.Controller
{
    public class DatabaseConfig
    {
        private readonly Dictionary<string, DataRow> _dadosIniciais;

        public DatabaseConfig()
        {
            _dadosIniciais = new Dictionary<string, DataRow>(StringComparer.OrdinalIgnoreCase);
        }

        public DatabaseConfig AddTableWithInitialData(string table, params DataRow[] dados)
        {
            foreach (DataRow record in dados)
            {
                _dadosIniciais.Add(table, record);
            }

            return this;
        }

        public Dictionary<string, DataRow> GetDadosIniciais() => _dadosIniciais;

    }
    public class Database : IDisposable
    {

        private readonly Dictionary<string, DataTable> _tables;
        public IReadOnlyDictionary<string, DataTable> Tables => _tables;

        public string DatabasePath => _basePath;
        private readonly string _basePath;

        public Database(string databaseName)
        {
            if (string.IsNullOrWhiteSpace(databaseName))
                throw new ArgumentException("Database name cannot be null or empty.", nameof(databaseName));

            _basePath = Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), databaseName, "data");
            _tables = new Dictionary<string, DataTable>(StringComparer.OrdinalIgnoreCase);
            Directory.CreateDirectory(_basePath);

            LoadTables();
        }

        public void InitializeDatabase(DatabaseConfig config)
        {
            foreach (var tableConfig in config.GetDadosIniciais())
            {
                var table = Tables[tableConfig.Key];
                var row = tableConfig.Value;

                table.Add(row);                
            }
        }

        private void LoadTables()
        {
            foreach (string tablePath in Directory.GetDirectories(_basePath))
            {
                // C:\\Users\\vinig\\AppData\\Local\\FluxoDeCaixa\\data\\user
                string tableName = tablePath.Replace(_basePath + "\\", string.Empty);

                _tables[tableName.ToUpper()] = new DataTable(tablePath);
            }
        }

        public void SaveChanges()
        {
            foreach (var table in Tables.Values)
            {
                table.SaveChanges();
            }
        }

        public void Dispose()
        {
            // Descartar recursos (se necessário) e liberar memória
            _tables.Clear();
            GC.SuppressFinalize(this);
        }

        ~Database()
        {
            Dispose();
        }
    }

    public class DataTable
    {
        private readonly Dictionary<string, DataRow> _rows;

        public List<DataRow> Rows { get; private set; } = new();

        private readonly string _tablePath;

        public DataTable(string filePath)
        {
            _tablePath = filePath;
            _rows = new Dictionary<string, DataRow>();

            Load();
        }

        public int Count => Rows.Count;

        private void Load()
        {
            if (Directory.Exists(_tablePath))
            {
                foreach (string fileRow in Directory.GetFiles(_tablePath))
                {
                    string json = File.ReadAllText(fileRow);
                    var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
                    if (data != null)
                    {
                        foreach (var record in data)
                        {
                            DataRow newRow = NewRow().LoadFromJson(json);
                            Rows.Add(newRow);
                        }
                    }
                }
            }

        }

        public void SaveChanges()
        {
            foreach (DataRow dataRow in Rows)
            {
                string path = Path.Combine(_tablePath, dataRow.GenerateFileName());
                var data = dataRow.GetValues();
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(path, json);
            }
        }

        public DataRow NewRow()
        {
            return new DataRow();
        }

        public void Add(DataRow row)
        {
            Rows.Add(row);
        }

        public DataRow First(Func<DataRow, bool> predicate)
        {
            return Rows.First(predicate);
        }

        public DataRow? FirstOrDefault(Func<DataRow, bool> predicate)
        {
            return Rows.FirstOrDefault(predicate);
        }

    }

    public class DataRow
    {
        private readonly Dictionary<string, object> _data;
        public string Id { get; set; }

        public DataRow(string id = null)
        {
            _data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            Id = id ?? Guid.NewGuid().ToString();
        }

        public DataRow(Dictionary<string, object> values)
        {
            _data = new Dictionary<string, object>(values, StringComparer.OrdinalIgnoreCase);
            Id = _data.ContainsKey("id") ? _data["id"].ToString() : Guid.NewGuid().ToString();
        }

        public object this[string columnName]
        {
            get
            {
                if (_data.TryGetValue(columnName, out var value))
                {
                    return value;
                }
                throw new KeyNotFoundException($"Column '{columnName}' not found.");
            }
            set
            {
                _data[columnName] = value;
            }
        }

        public DataRow LoadFromJson(string json)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if (data != null)
            {
                return new DataRow(data);
            }

            return null;
        }

        public string ToJson()
        {
            _data["_id"] = Id;
            return JsonConvert.SerializeObject(_data, Newtonsoft.Json.Formatting.Indented);
        }

        public Dictionary<string, object> GetValues()
        {
            return new Dictionary<string, object>(_data, StringComparer.OrdinalIgnoreCase);
        }

        public string GenerateFileName()
        {
            if (string.IsNullOrEmpty(Id))
                throw new InvalidOperationException("The 'id' field must be set before generating the file name.");

            return $"{Id}.json";
        }
    }
}
