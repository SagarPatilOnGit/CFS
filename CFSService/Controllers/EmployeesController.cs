using CFSService.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace CFSService.Controllers
{
	[EnableCors("http://localhost:4200", "*","*")]
	public class EmployeesController : ApiController
    {
        private DepartmentContext db = new DepartmentContext();

        // GET: api/Employees
        public IQueryable<Employees> GetEmployees()
        {
            return db.Employees.Include(x=> x.Department);
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> GetEmployees(int id)
        {
            Employees employees = await db.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
	        
            return Ok(employees);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployees(int id, Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employees.Id)
            {
                return BadRequest();
            }

            db.Entry(employees).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> PostEmployees(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employees);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employees.Id }, employees);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> DeleteEmployees(int id)
        {
            Employees employees = await db.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employees);
            await db.SaveChangesAsync();

            return Ok(employees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeesExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}