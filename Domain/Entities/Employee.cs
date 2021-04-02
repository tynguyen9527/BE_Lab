using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid PositionId { get; set; }

    }
}
