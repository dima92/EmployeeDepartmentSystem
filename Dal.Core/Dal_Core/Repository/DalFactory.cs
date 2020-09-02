using Dal.Core.Dal_Core.Interface;
using Dal.Core.EF;
using Dal.Core.GenericRepositoryModel.Interface;
using Dal.Core.GenericRepositoryModel.Repository;

namespace Dal.Core.Dal_Core.Repository
{
    public class DalFactory : IDalFactory
    {
        private IEmployeeDal _employee;
        private IDepartmentDal _department;

        private ApplicationContext _dbContext;
        private readonly IDbFactory _dbFactory;

        public DalFactory(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public ApplicationContext DbContext => _dbContext ??= _dbFactory.Init();

        public IEmployeeDal Employee => _employee ??= new EmployeeDaL(_dbFactory);
        public IDepartmentDal Department => _department ??= new DepartmentDal(_dbFactory);
    }
}