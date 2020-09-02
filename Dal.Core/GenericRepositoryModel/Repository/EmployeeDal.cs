using Dal.Core.Dal_Core.Interface;
using Dal.Core.Entities;
using Dal.Core.GenericRepository;
using Dal.Core.GenericRepositoryModel.Interface;

namespace Dal.Core.GenericRepositoryModel.Repository
{
    public class EmployeeDaL : GenericRepository<Employee>, IEmployeeDal
    {
        public EmployeeDaL(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}