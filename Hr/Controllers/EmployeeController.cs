using Hr.Interfaces;
using Hr.Models;
using Hr.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee IEmployee;
        public EmployeeController(IEmployee _IEmployee)
        {
            IEmployee = _IEmployee;
        }
        [HttpGet("GetAll")]
        public async Task<IReadOnlyList<Employee>> getall()
        {
            var data = await IEmployee.GetAllAsync();

            return data;
        }
        [HttpGet("GetAllData")]
        public  List<EmployeeVM> GetAllData()
        {
            var data =  IEmployee.GetallwithDeptName();

            return data;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) { return BadRequest("ID must be greater than zero."); }
            if (IEmployee.IdExists(id))
                return Ok(await IEmployee.GetByIdAsync(id));
           else
            {
                return NotFound("Id Not Found in database ");
            }
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, Employee Employee)
        {
           
            if (id != Employee.Id)
            {
                return BadRequest();
            }
            if(IEmployee.IdExists(Employee.Id))
            return Ok(await IEmployee.UpdateAsync(Employee));
            else
            {
                return NotFound("Id Not Found in database ");
               
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Employee Employee = new Employee();
            
            Employee.Id = id;
            return Ok(await IEmployee.DeleteAsync(Employee));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee Employee)
        {
            return Ok(await IEmployee.AddAsync(Employee));
        }
    }
}
