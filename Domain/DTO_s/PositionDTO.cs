using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO_s
{
    public class PositionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
