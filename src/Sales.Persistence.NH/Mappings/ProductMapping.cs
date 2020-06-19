using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using Sales.Domain.Model.Products;

namespace Sales.Persistence.NH.Mappings
{
    public class ProductMapping : ClassMapping<Product>
    {
        public ProductMapping()
        {
            Table("Products");

            Id(a => a.Id);
            Property(a => a.Color, c => c.NotNullable(true));
            Property(a => a.Name, c => c.NotNullable(true));
            Property(a => a.Description, c => c.NotNullable(true));
            ManyToOne(x => x.Category, c =>
            {
                c.Column("CategoryId");
            });

            Version("Timestamp", m =>
            {
                m.Column(c =>
                {
                    c.Name("RowVersion");
                    c.NotNullable(false);
                    c.SqlType("timestamp");
                });
                m.Insert(true);
                m.Generated(VersionGeneration.Always);
                m.UnsavedValue(null);
                m.Type(new BinaryBlobType());
            });
        }
    }
}