using Domain.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Http;
using Common.Paganation;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        public IEmployeeService _employeeService;
        string commonResponse = "The Department or Position do not exist";
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpPost("insert")]
        public IActionResult Insert([FromBody] EmployeeDTO dto)
        {
            var result = _employeeService.Insert(dto);
            if (!result)
            {
                return CommonResponse<string>(0, commonResponse);
            }
            return Ok(true);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] EmployeeDTO dto)
        {
            var result = _employeeService.Delete(dto);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }


        [HttpPut()]
        [Route("update")]
        public IActionResult Update([FromBody] EmployeeDTO dto)
        {
            var result = _employeeService.Update(dto);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }


        [HttpGet("getall")]
        public IActionResult GetAll([FromQuery] SerachPaganationDTO<EmployeeDTO> dto)
        {
            var result = _employeeService.GetAll(dto);
            if (result == null)
            {
                return Ok(false);
            }
            return Ok(result);
        }

    }
}
