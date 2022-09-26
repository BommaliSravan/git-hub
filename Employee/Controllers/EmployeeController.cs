
using EmployeeApplication.Core.Interfaces;
using EmployeeApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       
      
        private readonly IEmployeeRepositary _employeeRepo;

        public EmployeeController(IEmployeeRepositary employeeRepositary)
        {
            _employeeRepo = employeeRepositary;
        }

        
        [HttpGet ("Get")]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var result = _employeeRepo.GetEmployee();
                return StatusCode(200, result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("Post")]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _employeeRepo.InsertEmployee(employee);
                    return StatusCode(200, result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("Put")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                var result = _employeeRepo.UpdateEmployee(employee);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            try
            {
                var result = _employeeRepo.DeleteEmployee(Id);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

       
    }
}
