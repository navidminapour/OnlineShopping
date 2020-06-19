using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using System;
using Warehouse.Domain.Model.Stocks;

namespace Warehouse.Persistence.NH
{
    public class StockMapping : ClassMapping<Stock>
    {
        public StockMapping()
        {
            Table("Stocks");

            IdBag(a => a.Reservations, map =>
            {
                map.Table("Reservations");
                map.Key(a => a.Column("StoreId"));
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
                mapper.Property(a => a.CustomerId, c => c.NotNullable(true));
                mapper.Property(a => a.ExpirationTime, c => c.NotNullable(true));
                mapper.Property(a => a.ReservedCount, c => c.NotNullable(true));
            }));

            Id(a => a.Id);
            Property(a => a.Quantity, c => c.NotNullable(true));
            ManyToOne(x => x.Product, c =>
            {
                c.Column("ProductId");
            });
        }
    }
}
