using Framework.Domain;
using System.Collections.Generic;

namespace Sales.Domain.Model.Categories
{
    public class Category : AggregateRootBase<int>
    {
        public virtual string Name { get; protected set; }
        public virtual Category Parent { get; protected set; }
        public virtual IList<Category> Childs { get; protected set; }

        protected Category() { }
        public Category(int id, string name, Category parent)
        {
            this.Id = id;
            this.Name = name;
            this.Parent = parent;
        }
    }
}
