using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using NHibernate.UserTypes;
using Sales.Domain.Model.Categories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sales.Persistence.NH.Mappings
{
    public class CategoryMapping : ClassMapping<Category>
    {
        public CategoryMapping()
        {
            Table("Categories");
            Id(a => a.Id);

            Property(a => a.Name, c => c.NotNullable(true));

            
            ManyToOne(x => x.Parent, c=> 
            {
                c.Column("ParentId");
            });

            Bag(s => s.Childs, c =>
            {
                c.Lazy(CollectionLazy.NoLazy);
                c.Inverse(true);
                c.Key(k =>
                {
                    k.Column("ParentId");
                });
            },
            r => { r.OneToMany(); });

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
