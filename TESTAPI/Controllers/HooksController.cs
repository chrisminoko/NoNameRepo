using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TESTAPI.Interface;
using TESTAPI.Models;

namespace TESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HooksController : ControllerBase
    {
        private readonly IEmployee _employee;
        public HooksController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var data = await _employee.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {

                return BadRequest($"There was an Error - {ex}");
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _employee.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee staff)
        {
            var data = await _employee.AddAsync(staff);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _employee.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Employee staff)
        {
            var data = await _employee.UpdateAsync(staff);
            return Ok(data);
        }
    }
}
