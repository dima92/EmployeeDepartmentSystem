using System.Collections.Generic;

namespace Dal.Core.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}