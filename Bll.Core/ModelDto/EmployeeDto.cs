using Dal.Core.Entities;
using System.Collections.Generic;

namespace Bll.Core.ModelDto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Position { get; set; }
        public string Division { get; set; }

        public int DepartmentId { get; set; }
        public string Departments { get; set; }
    }
}