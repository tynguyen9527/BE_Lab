using Domain.DTO_s;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Departments
{
    public interface IDepartmentService
    {
        IQueryable<Department> GetAll();

        bool Insert(DepartmentDTO dto);

        bool Delete(DepartmentDTO dto);

        bool Update(DepartmentDTO dto);

    }
}
