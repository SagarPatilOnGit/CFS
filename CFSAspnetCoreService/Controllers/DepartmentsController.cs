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
	public class DepartmentsController : ControllerBase
	{
		private readonly Lazy<IUnitOfWork> _unitOfWork;
		public DepartmentsController(Lazy<IUnitOfWork> unitOfwork)
		{
            _unitOfWork = unitOfwork;
		}

		// GET: api/Departments
		[HttpGet]
		public IEnumerable<Departments> Get()
		{
			return _unitOfWork.Value.Department.GetAll();
		}

		// GET: api/Departments/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var department = _unitOfWork.Value.Department.Get(id);
			if (department == null)
			{
				return NotFound();
			}
			return Ok(department);
		}

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Departments department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != department.Id)
            {
                return BadRequest();
            }

            var dbDepartment = GetDepartment(id);
            _unitOfWork.Value.Department.Remove(dbDepartment);
            _unitOfWork.Value.Department.Add(department);
            _unitOfWork.Value.Complete();            
            return Ok(department);
        }

        // POST: api/Departments
        [HttpPost]
		public async Task<IActionResult> Post(Departments department)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
            _unitOfWork.Value.Department.Add(department);
            _unitOfWork.Value.Complete();
            return Ok();
		}

		// DELETE: api/Departments/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
            var department = GetDepartment(id);
            if (department == null)
			{
				return NotFound();
			}
            _unitOfWork.Value.Department.Remove(department);
            _unitOfWork.Value.Complete();
            return Ok(department);
		}

        private Departments GetDepartment(int id)
        {
            return _unitOfWork.Value.Department.Get(id);
        }
    }
}
