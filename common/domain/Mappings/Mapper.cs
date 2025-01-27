using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Mappings
{
    public class Mapper
    {
        public Mapper()
        {
            
        }

        private TDestino MapObject<TFonte, TDestino>(TFonte fonte)
        {
            Type tipoDaFonte = typeof(TFonte);
            Type tipoDoDestino = typeof(TDestino);

            string nomeDaFonte = tipoDaFonte.Name;
            string nomeDoDestino = tipoDoDestino.Name;

            PropertyInfo[] propriedadesDaFonte = tipoDaFonte.GetProperties();
            PropertyInfo[] propriedadesDoDestino = tipoDoDestino.GetProperties();

            TDestino destino = (TDestino)Activator.CreateInstance(tipoDoDestino);

            foreach (PropertyInfo propD in propriedadesDoDestino)
            {
                string _propD = propD.Name.ToLowerInvariant();

                PropertyInfo propF = propriedadesDaFonte.FirstOrDefault(pf => string.Equals(pf.Name, _propD, StringComparison.InvariantCultureIgnoreCase));
                if (propF != null)
                {
                    string _propF = propF.Name.ToLowerInvariant();

                    if (propF.PropertyType.IsGenericType && propF.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        //MAPEAR A LISTA
                        System.Collections.IList listaFonte = (System.Collections.IList)propF.GetValue(fonte);
                        if (listaFonte != null && listaFonte.Count > 0)
                        {
                            Type tipoListaFonte = listaFonte[0].GetType();

                            Type tipoListaDestino = GetMappingTypeByName(tipoListaFonte.Name);

                            if (tipoListaDestino == null)
                                continue;

                            var m = typeof(Mapper).GetMethod(nameof(Mapper.MapList));
                            var gm = m.MakeGenericMethod(new Type[] { tipoListaFonte, tipoListaDestino });

                            var listaDestino = gm.Invoke(new Mapper(), new object[] { listaFonte });

                            propD.SetValue(destino, listaDestino);
                        }
                        else
                        {
                            propD.SetValue(destino, null);
                        }
                        continue;
                    }

                    object valorFonte = propF.GetValue(fonte);

                    if (valorFonte == null)
                    {
                        propD.SetValue(destino, valorFonte);
                        continue;
                    }

                    if (propD.PropertyType.Equals(propF.PropertyType))
                    {
                        propD.SetValue(destino, valorFonte);
                        continue;
                    }

                    if (propD.PropertyType.Equals(typeof(int)) && propF.PropertyType.Equals(typeof(decimal)))
                    {
                        propD.SetValue(destino, Convert.ToInt32(valorFonte));
                        continue;
                    }

                    if (propD.PropertyType.Equals(typeof(decimal)) && propF.PropertyType.Equals(typeof(int)))
                    {
                        propD.SetValue(destino, Convert.ToDecimal(valorFonte));
                        continue;
                    }

                    if (propD.PropertyType.Equals(typeof(long)) && propF.PropertyType.Equals(typeof(decimal)))
                    {
                        propD.SetValue(destino, Convert.ToInt64(valorFonte));
                        continue;
                    }

                    if (propD.PropertyType.Equals(typeof(decimal)) && propF.PropertyType.Equals(typeof(long)))
                    {
                        propD.SetValue(destino, Convert.ToDecimal(valorFonte));
                        continue;
                    }

                    if (propD.PropertyType.Equals(typeof(bool)) && propF.PropertyType.Equals(typeof(bool?)))
                    {
                        if (valorFonte == null)
                        {
                            //string valorPadraoDestino = propD.GetCustomAttribute<DefaultAttribute>()?.DefaultValue ??
                            //                            propD.GetCustomAttribute<PostgreDefaultAttribute>()?.DefaultValue;

                            string valorPadraoDestino = "false";

                            propD.SetValue(destino, "true".Equals(valorPadraoDestino));
                        }
                        else
                        {
                            propD.SetValue(destino, Convert.ToBoolean(valorFonte));
                        }
                        continue;
                    }

                    if (propD.PropertyType.Equals(typeof(bool)) ||
                        propD.PropertyType.Equals(typeof(bool?)))
                        if (propF.PropertyType.Equals(typeof(int)) ||
                            propF.PropertyType.Equals(typeof(int?)) ||
                            propF.PropertyType.Equals(typeof(decimal)) ||
                            propF.PropertyType.Equals(typeof(decimal?)) ||
                            propF.PropertyType.Equals(typeof(long)) ||
                            propF.PropertyType.Equals(typeof(long?)))
                        {
                            switch (valorFonte)
                            {
                                case 1L:
                                case 1M:
                                case 1:
                                    propD.SetValue(destino, true); break;
                                default:
                                    propD.SetValue(destino, false); break;
                            }
                            continue;
                        }

                    if (propD.PropertyType.Equals(typeof(int)) ||
                        propD.PropertyType.Equals(typeof(int?)) ||
                        propD.PropertyType.Equals(typeof(decimal)) ||
                        propD.PropertyType.Equals(typeof(decimal?)) ||
                        propD.PropertyType.Equals(typeof(long)) ||
                        propD.PropertyType.Equals(typeof(long?)))
                        if (propF.PropertyType.Equals(typeof(bool)) ||
                            propF.PropertyType.Equals(typeof(bool?)))
                        {
                            switch (valorFonte)
                            {
                                case true:
                                    if (propD.PropertyType.Equals(typeof(int)) ||
                                        propD.PropertyType.Equals(typeof(int?)))
                                    {
                                        propD.SetValue(destino, 1);
                                        break;
                                    }

                                    if (propD.PropertyType.Equals(typeof(decimal)) ||
                                        propD.PropertyType.Equals(typeof(decimal?)))
                                    {
                                        propD.SetValue(destino, 1M);
                                        break;
                                    }

                                    if (propD.PropertyType.Equals(typeof(long)) ||
                                        propD.PropertyType.Equals(typeof(long?)))
                                    {
                                        propD.SetValue(destino, 1L);
                                        break;
                                    }

                                    break;
                                default:
                                    if (propD.PropertyType.Equals(typeof(int)) ||
                                        propD.PropertyType.Equals(typeof(int?)))
                                    {
                                        propD.SetValue(destino, 0);
                                        break;
                                    }

                                    if (propD.PropertyType.Equals(typeof(decimal)) ||
                                        propD.PropertyType.Equals(typeof(decimal?)))
                                    {
                                        propD.SetValue(destino, 0M);
                                        break;
                                    }

                                    if (propD.PropertyType.Equals(typeof(long)) ||
                                        propD.PropertyType.Equals(typeof(long?)))
                                    {
                                        propD.SetValue(destino, 0L);
                                        break;
                                    }
                                    break;
                            }
                            continue;
                        }

                    TypeConverter conversor = TypeDescriptor.GetConverter(propD.PropertyType);
                    if (!conversor.CanConvertFrom(propF.PropertyType))
                        throw new Exception($"O campo {propF.Name} não consegue converter de {propF.PropertyType} para {propD.PropertyType}!");

                    object valorConvertido = conversor.ConvertFrom(valorFonte);

                    propD.SetValue(destino, valorConvertido);

                    continue;
                }
            }

            return destino;
        }

        public TDestino Map<TFonte, TDestino>(TFonte o)
        {
            if (o == null)
                return default;

            return MapObject<TFonte, TDestino>(o);
        }

        public IEnumerable<TDestino> MapList<TFonte, TDestino>(IEnumerable<TFonte> o)
        {
            if (o == null)
                return null;

            var lista = new List<TDestino>();
            foreach (var item in o)
                lista.Add(MapObject<TFonte, TDestino>(item));
            return lista;
        }

        private static Type GetMappingTypeByName(string sourceTypeName)
        {
            //Buscar Type no Assembly
            return AppDomain.CurrentDomain.GetAssemblies()
             .Reverse()
             .SelectMany(assembly => assembly.GetTypes())
             .FirstOrDefault(t => t.Name.ToLowerInvariant().Contains(sourceTypeName.ToLowerInvariant()));
        }
    }
}
