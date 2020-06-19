using NHibernate;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Data;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Event;
using FluentNHibernate.Cfg;

namespace Framework.NH
{
    public static class SessionFactoryBuilder
    {
        public static ISessionFactory CreateByConnectionString(string connectionString, Assembly mappingAssembly)
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(cfg =>
            {
                cfg.Dialect<MsSql2012Dialect>();
                cfg.Driver<SqlClientDriver>();
                cfg.ConnectionString = connectionString;
                cfg.IsolationLevel = IsolationLevel.ReadCommitted;
            });

            return Create(configuration, mappingAssembly);
        }

        public static ISessionFactory CreateByConnectionStringName(string connectionStringName, Assembly mappingAssembly)
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(cfg =>
            {
                cfg.Dialect<MsSql2012Dialect>();
                cfg.Driver<SqlClientDriver>();
                cfg.ConnectionStringName = connectionStringName;
                cfg.IsolationLevel = IsolationLevel.ReadCommitted;
            });
            return Create(configuration, mappingAssembly);
        }

        private static ISessionFactory Create(Configuration configuration, Assembly mappingAssembly)
        {
            configuration.EventListeners.PostInsertEventListeners = new IPostInsertEventListener[] { new DomainEventListener() };
            configuration.EventListeners.PostDeleteEventListeners = new IPostDeleteEventListener[] { new DomainEventListener() };
            configuration.EventListeners.PostUpdateEventListeners = new IPostUpdateEventListener[] { new DomainEventListener() };
            configuration.EventListeners.PostCollectionUpdateEventListeners = new IPostCollectionUpdateEventListener[] { new DomainEventListener() };
            var modelMapper = new ModelMapper();
            modelMapper.AddMappings(mappingAssembly.GetExportedTypes());
            var hbmMapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(hbmMapping, "test");
            new SchemaUpdate(configuration).Execute(false, true);
            return configuration.BuildSessionFactory();
        }
    }
}