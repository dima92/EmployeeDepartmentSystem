using Dal.Core.Dal_Core.Interface;
using Dal.Core.Entities;
using Dal.Core.GenericRepository;
using Dal.Core.GenericRepositoryModel.Interface;

namespace Dal.Core.GenericRepositoryModel.Repository
{
    public class DepartmentDal : GenericRepository<Department>, IDepartmentDal
    {
        public DepartmentDal(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}