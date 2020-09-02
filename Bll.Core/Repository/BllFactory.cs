using AutoMapper;
using Bll.Core.Interface;
using Dal.Core.Dal_Core.Repository;

namespace Bll.Core.Repository
{
    public class BllFactory : IBllFactory
    {
        private readonly DalFactory _dalFactory;
        private readonly IMapper _mapper;

        private IEmployeeBll _employeeBll;
        private IDepartmentBll _departmentBll;

        public BllFactory(IMapper mapper)
        {
            _mapper = mapper;
            _dalFactory = new DalFactory(new DbFactory());
        }

        public IEmployeeBll EmployeeBll => _employeeBll ??= new EmployeeBll(_dalFactory, _mapper);
        public IDepartmentBll DepartmentBll => _departmentBll ??= new DepartmentBll(_dalFactory, _mapper);
    }
}