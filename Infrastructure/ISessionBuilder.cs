using NHibernate;

namespace Infrastructure
{
    public interface ISessionBuilder
    {
        ISession GetSession();
    }
}