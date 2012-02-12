using NHibernate;

namespace Infrastructure
{
    public interface ISessionFactoryBuilder
    {
        ISessionFactory GetFactory();
    }
}