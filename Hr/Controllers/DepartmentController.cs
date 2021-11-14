using Hr.Interfaces;
using Hr.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly Idepartment Idepartment;
        private readonly IEmployee IEmployee;
        public DepartmentController(Idepartment _Idepartment, IEmployee _IEmployee)
    {
            Idepartment = _Idepartment;
            IEmployee = _IEmployee;
    }
     [HttpGet("GetAll")]
        public async Task<IReadOnlyList<Department>> getall()
    {
            var data = await Idepartment.GetAllAsync();

        return data;
    }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) { return BadRequest("ID must be greater than zero."); }
            if (Idepartment.IdExists(id))
                return Ok(await Idepartment.GetByIdAsync(id));
            else
            {
                return NotFound("Id not Found in Databaase");
            }
                
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department Department)
        {
            return Ok(await Idepartment.AddAsync(Department));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Department Department)
        {
            if (id != Department.Id)
            {
                return BadRequest();
            }
            if (Idepartment.IdExists(id))
                return Ok(await Idepartment.UpdateAsync(Department));
            else
            {
                return NotFound("Id not Found in Databaase");
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(Idepartment.departentInUse(id)==true)
            {
                return BadRequest("Department already in use");
            }
            Department Department = new Department();
           
            Department.Id = id;
            return Ok(await Idepartment.DeleteAsync(Department));
        }
    }
}
