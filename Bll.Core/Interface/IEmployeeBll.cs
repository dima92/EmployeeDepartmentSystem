using Bll.Core.ModelDto;
using Dal.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bll.Core.Interface
{
    public interface IEmployeeBll
    {
        List<EmployeeDto> GetAll();
        Employee GetById(int employeeId);
        void Add(EmployeeDto employee);
        void Update(EmployeeDto employee);
        void Delete(int employeeId);
    }
}