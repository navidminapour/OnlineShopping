using Framework.Domain;
using Sales.Domain.Model.Categories;
using System;

namespace Sales.Domain.Model.Products
{
    public class Product : AggregateRootBase<long>
    {
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual Color Color { get; protected set; }
        public virtual Category Category { get; protected set; }

        protected Product() { }

        public Product(long id, string name, string description, Color color, Category category)
        {
            if (category == null)
                throw new Exception();

            if(string.IsNullOrEmpty(name))
                throw new Exception();

            if (string.IsNullOrEmpty(description))
                throw new Exception();

            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Color = color;
            this.Category = category;
        }
    }
}
