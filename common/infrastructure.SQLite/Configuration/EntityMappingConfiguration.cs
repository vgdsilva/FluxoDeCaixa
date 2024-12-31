using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FluxoDeCaixa.Infrastructure.SQLite.Configuration
{
    public class EntityMappingConfiguration
    {
        protected Type EntityType { get; set; }
        protected EntityTypeBuilder EntityBuilder { get; set; }
        protected IMutableEntityType EntityMetadata { get; set; }

        public EntityMappingConfiguration(Type entityType)
        {
            EntityType = entityType;
        }

        public void Map(ModelBuilder modelBuilder)
        {
            this.EntityBuilder = modelBuilder.Entity(EntityType);
            this.EntityMetadata = EntityBuilder.Metadata;

            // Altera o nome da tabela para o nome da classe em caixa baixa
            //EntityMetadata.Relational().TableName = EntityMetadata.Relational().TableName.ToLower();

            //CustomizeEntityMap(modelBuilder);

            // Altera o nome das colunas para o nome em caixa baixa
            foreach (var property in EntityMetadata.GetProperties())
            {
                //PropertyMap(property);

                //CustomizePropertyMap(property);
            }

            var cascadeFKs = EntityMetadata.GetForeignKeys()
                        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        //protected void PropertyMap(IMutableProperty property)
        //{
        //    property.Relational() = property.Relational().ColumnName.ToLower();

        //    var propertyType = property.ClrType;
        //    if (propertyType.IsEnum)
        //    {
        //        //var mappingHints = new ConverterMappingHints(valueGeneratorFactory: (p, t) => new TemporaryIntValueGenerator());
        //        //var converterType = TypeUtils.CreateType(typeof(EnumToIntValueConverter<>), propertyType);
        //        //var converter = Activator.CreateInstance(converterType, mappingHints);
        //        //property.SetValueConverter((ValueConverter)converter);
        //    }
        //    else if (propertyType == typeof(bool) || Nullable.GetUnderlyingType(propertyType) == typeof(bool))
        //    {
        //        var mappingHints = new ConverterMappingHints(valueGeneratorFactory: (p, t) => new TemporaryIntValueGenerator());
        //        property.SetValueConverter(new BoolToZeroOneConverter<int>(mappingHints));
        //    }
        //}
    }
}
