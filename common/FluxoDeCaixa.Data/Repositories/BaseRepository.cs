using FluxoDeCaixa.Domain.ValueObjects;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Data.Repositories
{
    public abstract class BaseRepository<T> where T : new()
    {
        protected readonly DbConnection _dbConnection;

        protected BaseRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            await _dbConnection.Init();
            return await _dbConnection.Database.FindAsync<T>(id);
        }
        
        public async Task<List<T>> GetAllAsync()
        {
            await _dbConnection.Init();
            return await _dbConnection.Database.Table<T>().ToListAsync();
        }

        /// <summary>
        /// Salva o registro: insere se não existir, atualiza se já existir.
        /// </summary>
        /// <param name="entity">A entidade a ser salva.</param>
        /// <param name="primaryKey">O nome da propriedade chave primária.</param>
        /// <returns>O número de linhas afetadas.</returns>
        public async Task<int> SaveAsync(T entity)
        {
            await _dbConnection.Init();

            // Usa reflexão para obter o valor da chave primária
            var propertyInfo = typeof(T).GetProperty(nameof(EntityControl.Id));
            if (propertyInfo == null)
            {
                throw new InvalidOperationException($"A chave primária '{nameof(EntityControl.Id)}' não foi encontrada na entidade {typeof(T).Name}.");
            }

            var primaryKeyValue = propertyInfo.GetValue(entity);

            // Verifica se o registro já existe
            if (primaryKeyValue != null && await _dbConnection.Database.FindAsync<T>(primaryKeyValue) != null)
            {
                // Atualiza o registro existente
                return await _dbConnection.Database.UpdateAsync(entity);
            }
            else
            {
                // Insere o novo registro
                return await _dbConnection.Database.InsertAsync(entity);
            }
        }
    }
}
