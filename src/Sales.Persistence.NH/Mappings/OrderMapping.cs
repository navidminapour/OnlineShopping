using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using Sales.Domain.Model.Orders;

namespace Sales.Persistence.NH.Mappings
{
    public class OrderMapping : ClassMapping<Order>
    {
        public OrderMapping()
        {
            Table("Orders");

            IdBag(a => a.Items, map =>
            {
                map.Table("OrderItems");
                map.Key(a => a.Column("OrderId"));
                map.Cascade(Cascade.All);
                map.Lazy(CollectionLazy.NoLazy);
                map.Id(a =>
                {
                    a.Column("Id");
                    a.Type(new Int64Type());
                    a.Generator(Generators.Identity);
                });
            }, relation => relation.Component(mapper =>
            {
                mapper.Property(a => a.Quantity, c => c.NotNullable(true));
                mapper.Property(a => a.IsReserved, c => c.NotNullable(true));
                mapper.ManyToOne(x => x.Product, c =>
                {
                    c.Column("ProductId");
                });
            }));

            Id(a => a.Id);
            Property(a => a.CustomerId, c => c.NotNullable(true));
            Property(a => a.OrderState, c => c.NotNullable(true));
            //Component(a => a.Address, a =>
            //{
            //    a.Property(p => p.Country, c => { c.Column("Address_Country"); c.NotNullable(true); });
            //    a.Property(p => p.City, c => {c.Column("Address_City"); c.NotNullable(true); });
            //    a.Property(p => p.Street, c => {c.Column("Address_Street"); c.NotNullable(true); });
            //    a.Property(p => p.Number, c => {c.Column("Address_Number"); c.NotNullable(true); });
            //    a.Property(p => p.Unit, c => {c.Column("Address_Unit"); c.NotNullable(true); });
            //    a.Property(p => p.ZipCode, c => {c.Column("Address_ZipCode"); c.NotNullable(true); });
            //    a.Property(p => p.Latitude, c => c.Column("Address_Latitude"));
            //    a.Property(p => p.Longitude, c => c.Column("Address_Longitude"));
            //    a.Lazy(false);
            //});

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