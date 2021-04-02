﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {

        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
