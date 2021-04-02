using Domain.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        public IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] PositionDTO dto)
        {
            var result = _positionService.Insert(dto);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] PositionDTO dto)
        {
            var result = _positionService.Delete(dto);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }


        [HttpPut()]
        [Route("update")]
        public IActionResult Update([FromBody] PositionDTO dto)
        {
            var result = _positionService.Update(dto);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _positionService.GetAll();
            if (result == null)
            {
                return Ok(false);
            }
            return Ok(result);
        }
    }
}
