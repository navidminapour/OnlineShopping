using NHibernate;

namespace Framework.NH
{
    public static class SequenceHelper
    {
        public static T NextSequenceValue<T>(this ISession session, string sequenceName)
        {
            return session.CreateSQLQuery($"SELECT NEXT VALUE FOR {sequenceName}").UniqueResult<T>();
        }
    }
}