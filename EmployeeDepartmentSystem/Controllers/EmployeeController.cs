using Bll.Core.Infrastructure;
using Bll.Core.Interface;
using Bll.Core.ModelDto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeDepartmentSystem.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IBllFactory _bllFactory;
        public EmployeeController(IBllFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allEmployees = _bllFactory.EmployeeBll.GetAll();
                return Ok(allEmployees);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployees(int id)
        {
            var result = _bllFactory.EmployeeBll.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(EmployeeDto employee)
        {
            try
            {
                _bllFactory.EmployeeBll.Add(employee);
                return Ok();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update(EmployeeDto data)
        {
            try
            {
                _bllFactory.EmployeeBll.Update(data);
                return Ok();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bllFactory.EmployeeBll.Delete(id);
                return Ok();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
