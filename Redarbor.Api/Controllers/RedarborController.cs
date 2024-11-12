using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redarbor.Core.Entities;
using Redarbor.Core.Interfaces;

namespace Redarbor.Api.Controllers
{
    public class RedarborController : Controller
    {
        private readonly IRedarbor _redarbor;

        public RedarborController(IRedarbor redarbor)
        {
            _redarbor = redarbor;
        }

        //[HttpGet]
        //[Route("api/redarbor")]
        //public async Task<ActionResult<List<Employee>>> GetEmployeesList(int? id)
        //{
        //    List<Employee> employee = await _redarbor.GetEmployees(id);
        //    return Ok(employee);
        //}

        [HttpGet]
        [Route("api/redarbor")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesList()
        {
            try
            {
                List<Employee> employee = await _redarbor.GetEmployees();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/redarbor/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeesById(int id)
        {
            try
            {
                Employee employee = await _redarbor.GetEmployeesById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/redarbor")]
        public async Task<ActionResult<Employee>> PostEmployees([FromBody] Employee employee)
        {
            try
            {
                Employee employ = await _redarbor.PostEmployees(employee);
                if (employ == null) return NotFound();
                return Ok(employ);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/redarbor/{id}")]
        public async Task<ActionResult<bool>> PutEmployees([FromBody] Employee employee)
        {
            try
            {
                bool employ = await _redarbor.PutEmployees(employee);
                return Ok(employ);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/redarbor/{id}")]
        public async Task<ActionResult<bool>> DeleteEmployees(int id)
        {
            try
            {
                var result = await _redarbor.DeleteEmployees(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
