using AutoMapper;
using Bll.Core.Infrastructure;
using Bll.Core.Interface;
using Bll.Core.ModelDto;
using Dal.Core.Dal_Core.Repository;
using Dal.Core.EF;
using Dal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bll.Core.Repository
{
    public class DepartmentBll : IDepartmentBll
    {
        private readonly ApplicationContext _context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        private readonly DalFactory _dalFactory;
        private readonly IMapper _mapper;

        public DepartmentBll(DalFactory dalFactory, IMapper mapper)
        {
            _dalFactory = dalFactory;
            _mapper = mapper;
        }

        public List<DepartmentDto> GetAll()
        {
            List<DepartmentDto> result = new List<DepartmentDto>();
            var allDepartments = _dalFactory.Department.GetAll().ToList();
            foreach (var department in allDepartments)
            {
                result.Add(new DepartmentDto
                {
                    Id = department.Id,
                    Name = department.Name
                });
            }

            return result.OrderBy(x => x.Name).ToList();
        }

        public Department GetById(int departmentId)
        {
            return _dalFactory.Department.GetById(departmentId);
        }

        public void Add(DepartmentDto department)
        {
            Department result = _mapper.Map<DepartmentDto, Department>(department);
            _dalFactory.Department.Add(result);
        }

        public void Update(DepartmentDto department)
        {
            Department result = _mapper.Map<DepartmentDto, Department>(department);
            _dalFactory.Department.UpdateVoid(result, result.Id);
        }

        public void Delete(int departmentId)
        {
            Department department = _dalFactory.Department.First(x => x.Id == departmentId);

            if (_dalFactory.Department.Any(a => a.Id == departmentId))
            {
                _dalFactory.Department.Delete(department ?? throw new ValidationException("Произошла ошибка во время удаления"));
            }

            _dalFactory.DbContext.SaveChanges();
        }
    }
}