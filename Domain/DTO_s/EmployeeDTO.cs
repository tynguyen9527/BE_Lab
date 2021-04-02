using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO_s
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
    }

}
