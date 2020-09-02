using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Bll.Core.Infrastructure;
using Bll.Core.Interface;
using Bll.Core.ModelDto;
using Dal.Core.Dal_Core.Repository;
using Dal.Core.EF;
using Dal.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bll.Core.Repository
{
    public class EmployeeBll : IEmployeeBll
    {
        private readonly ApplicationContext _context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        private readonly DalFactory _dalFactory;
        private readonly IMapper _mapper;

        public EmployeeBll(DalFactory dalFactory, IMapper mapper)
        {
            _dalFactory = dalFactory;
            _mapper = mapper;
        }

        public List<EmployeeDto> GetAll()
        {
            List<EmployeeDto> result = new List<EmployeeDto>();
            var allEmployees = _context.Employees.Include(dep => dep.Departments).ToList();
            foreach (var employee in allEmployees)
            {
                result.Add(new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Address = employee.Address,
                    Position = employee.Position,
                    Division = employee.Division,
                    Number = employee.Number,
                    DepartmentId = employee.DepartmentId,
                    Departments = employee.Departments.Name
                });
            }

            return result;
        }

        public async Task EmployeeDto()
        {
            using (FileStream fs = new FileStream("employee.json", FileMode.OpenOrCreate))
            {
                EmployeeDto employee = new EmployeeDto();
                await JsonSerializer.SerializeAsync(fs, employee);
            }
        }

        public Employee GetById(int employeeId)
        {
            return _dalFactory.Employee.GetById(employeeId);
        }

        public void Add(EmployeeDto employee)
        {
            Employee result = _mapper.Map<EmployeeDto, Employee>(employee);
            _dalFactory.Employee.Add(result);
        }

        public void Update(EmployeeDto employee)
        {
            Employee result = _mapper.Map<EmployeeDto, Employee>(employee);
            _dalFactory.Employee.UpdateVoid(result, result.Id);
        }

        public void Delete(int employeeId)
        {
            Employee employee = _dalFactory.Employee.First(x => x.Id == employeeId);

            if (_dalFactory.Employee.Any(a => a.Id == employeeId))
            {
                _dalFactory.Employee.Delete(employee ?? throw new ValidationException("Произошла ошибка во время удаления"));
            }

            _dalFactory.DbContext.SaveChanges();
        }
    }
}