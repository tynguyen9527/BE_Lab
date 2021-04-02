using Domain.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] DepartmentDTO dto)
        {
            var result = _departmentService.Insert(dto);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DepartmentDTO dto)
        {
            var result = _departmentService.Delete(dto);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }


        [HttpPut()]
        [Route("update")]
        public IActionResult Update([FromBody]DepartmentDTO dto)
        {
            var result = _departmentService.Update(dto);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _departmentService.GetAll();
            if (result == null)
            {
                return Ok(false);
            }
            return Ok(result);
        }

    }
}
