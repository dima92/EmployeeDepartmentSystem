using AutoMapper;
using Bll.Core.ModelDto;
using Dal.Core.Entities;

namespace Bll.Core.Mapper
{
    public class MapperEmployee : Profile
    {
        public MapperEmployee()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>()
                .ForMember(d => d.Departments, opt => opt.MapFrom(src => AddNull()));
        }

        private static object AddNull()
        {
            return null;
        }

    }
}