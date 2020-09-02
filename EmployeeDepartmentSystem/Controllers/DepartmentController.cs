using Bll.Core.Infrastructure;
using Bll.Core.Interface;
using Bll.Core.ModelDto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeDepartmentSystem.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IBllFactory _bllFactory;
        public DepartmentController(IBllFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allDepartments = _bllFactory.DepartmentBll.GetAll();
                return Ok(allDepartments);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartments(int id)
        {
            var result = _bllFactory.DepartmentBll.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(DepartmentDto department)
        {
            try
            {
                _bllFactory.DepartmentBll.Add(department);
                return Ok();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update(DepartmentDto data)
        {
            try
            {
                _bllFactory.DepartmentBll.Update(data);
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
                _bllFactory.DepartmentBll.Delete(id);
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
