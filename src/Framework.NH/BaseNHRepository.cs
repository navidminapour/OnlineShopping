using Framework.Core;
using Framework.Core.Events;
using Framework.Domain;
using NHibernate;

namespace Framework.NH
{
    public class BaseNhRepository<TKey, T> where T : AggregateRootBase<TKey>
    {
        protected ISession Session { get; private set; }

        protected BaseNhRepository(ISession session)
        {
            Session = session;
        }

        public T LoadAggregate(TKey id)
        {
            var aggregateRoot = Session.Get<T>(id);
            return aggregateRoot;
        }

        public TKey GetNextId()
        {
            return Session.NextSequenceValue<TKey>($"{typeof(T).Name}_Seq");
        }
    }
}
