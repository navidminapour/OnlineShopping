using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using Warehouse.Domain.Model.Products;

namespace Warehouse.Persistence.NH.Mappings
{
    public class ProductMapping : ClassMapping<Product>
    {
        public ProductMapping()
        {
            Table("Products");
            Id(a => a.Id);
            Property(p => p.Height, c => c.NotNullable(true));
            Property(p => p.Length, c => c.NotNullable(true));
            Property(p => p.Width, c => c.NotNullable(true));
        }
    }
}
