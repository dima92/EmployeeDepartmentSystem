using System.Collections.Generic;
using Bll.Core.ModelDto;
using Dal.Core.Entities;

namespace Bll.Core.Interface
{
    public interface IDepartmentBll
    {
        List<DepartmentDto> GetAll();
        Department GetById(int departmentId);
        void Add(DepartmentDto department);
        void Update(DepartmentDto department);
        void Delete(int departmentId);
    }
}