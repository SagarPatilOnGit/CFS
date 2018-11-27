using CFSAspnetCoreService.Data.UoW;
using CFSAspnetCoreService.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CFSAspnetCoreService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class EmployeesController : ControllerBase
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        public EmployeesController(Lazy<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Employees/{pageIndex}/{pageSize}
        [HttpGet]
        [Route("{pageIndex}/{pageSize}")]
		public IEnumerable<Employees> GetEmployeesWithDepartment(int pageIndex, int pageSize = 10)
		{
            return _unitOfWork.Value.Employee.GetEmployeesWithDepartment(pageIndex, pageSize);
		}

		// GET: api/Employees/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{			
			return Ok(_unitOfWork.Value.Employee.Get(id));
		}

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employees employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != employee.Id)
            {
                return BadRequest();
            }

            var dbEmployee = GetEmployee(id);
            _unitOfWork.Value.Employee.Remove(dbEmployee);
            _unitOfWork.Value.Employee.Add(employee);
            _unitOfWork.Value.Complete();
            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
		public async Task<IActionResult> Post(Employees employees)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
            _unitOfWork.Value.Employee.Add(employees);
            _unitOfWork.Value.Complete();
            return Ok();
		}

		// DELETE: api/Employees/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
            var employees = GetEmployee(id);
			if (employees == null)
			{
				return NotFound();
			}
            _unitOfWork.Value.Employee.Remove(employees);
            _unitOfWork.Value.Complete();
            return Ok(employees);
		}

        private Employees GetEmployee(int id)
        {
            return _unitOfWork.Value.Employee.Get(id);
        }
	}
}
