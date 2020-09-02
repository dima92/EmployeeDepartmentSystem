namespace Bll.Core.Interface
{
    public interface IBllFactory
    { 
        IEmployeeBll EmployeeBll { get; }
        IDepartmentBll DepartmentBll { get; }
    }
}