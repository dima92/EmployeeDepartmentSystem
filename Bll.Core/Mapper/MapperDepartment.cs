using AutoMapper;
using Bll.Core.ModelDto;
using Dal.Core.Entities;

namespace Bll.Core.Mapper
{
    public class MapperDepartment : Profile
    {
        public MapperDepartment()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
        }
    }
}