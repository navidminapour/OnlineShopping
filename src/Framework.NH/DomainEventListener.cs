using Framework.Core;
using Framework.Core.Events;
using Framework.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NHibernate.Event;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.NH
{
    public class DomainEventListener :
        IPostInsertEventListener,
        IPostDeleteEventListener,
        IPostUpdateEventListener,
        IPostCollectionUpdateEventListener
        
    {
        public Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPostInsert(PostInsertEvent @event)
        {
            DispatchEvents(@event.Entity as IAggregateRoot, @event.Session);
        }

        public Task OnPostDeleteAsync(PostDeleteEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPostDelete(PostDeleteEvent @event)
        {
            DispatchEvents(@event.Entity as IAggregateRoot, @event.Session);
        }

        public Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            DispatchEvents(@event.Entity as IAggregateRoot, @event.Session);
        }

        public Task OnPostUpdateCollectionAsync(PostCollectionUpdateEvent @event, CancellationToken cancellationToken)
        {
            //TODO: Implement The Method
            throw new NotImplementedException();
        }

        public void OnPostUpdateCollection(PostCollectionUpdateEvent @event)
        {
            DispatchEvents(@event.AffectedOwnerOrNull as IAggregateRoot, @event.Session);
        }


        private void DispatchEvents(IAggregateRoot aggregateRoot, IEventSource session)
        {
            var connectionString =
                "Server=mssqldb;Database=EventDispatcher;Integrated Security=False;User=sa;Password=MyPassw0rd123456;MultipleActiveResultSets=True;";
            var connection = new SqlConnection(connectionString);
            string commandText = string.Empty;
            SqlCommand command = new SqlCommand();
            try
            {
                connection.Open();

                if (aggregateRoot == null)
                    return;

                foreach (DomainEvent domainEvent in aggregateRoot.DomainEvents)
                {
                    DomainEventDispatcher.Dispatch(domainEvent);
                    commandText += $"INSERT INTO [Events] ([Id],[EventType],[SerializedContent],[CreationDateTime],[IsProcessed]) Values('{domainEvent.EventId}', '{domainEvent.GetType().Name}','{ JsonConvert.SerializeObject(domainEvent)}','{domainEvent.PublishDateTime}',0);";
                }
                if(!string.IsNullOrWhiteSpace(commandText))
                {
                    command.CommandText = commandText;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                aggregateRoot.ClearEvents();
                
            }
            catch(Exception ex)
            {
                command?.Transaction?.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}