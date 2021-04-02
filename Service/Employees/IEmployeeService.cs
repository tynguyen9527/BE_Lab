using Common.Paganation;
using Domain.DTO_s;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Employees
{
    public interface IEmployeeService
    {
        Paganation<EmployeeDTO> GetAll(SerachPaganationDTO<EmployeeDTO> dto);

        bool Insert(EmployeeDTO dto);

        bool Delete(EmployeeDTO dto);

        bool Update(EmployeeDTO dto);
    }
}
