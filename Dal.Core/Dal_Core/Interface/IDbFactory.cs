using Dal.Core.EF;

namespace Dal.Core.Dal_Core.Interface
{
    public interface IDbFactory
    {
        ApplicationContext Init();
    }
}