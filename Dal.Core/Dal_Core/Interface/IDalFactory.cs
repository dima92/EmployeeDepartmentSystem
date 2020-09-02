using Dal.Core.GenericRepositoryModel.Interface;

namespace Dal.Core.Dal_Core.Interface
{
    public interface IDalFactory
    {
        IEmployeeDal Employee { get; }
        IDepartmentDal Department { get; }
    }
}
