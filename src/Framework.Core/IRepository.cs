namespace Framework.Core
{
    public interface IRepository<out T>
    {
        T GetNextId();
    }
}