using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.Models;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchEmployee_ResultController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public SearchEmployee_ResultController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/SearchEmployee_Result
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchEmployee_Result>>> GetEmployeeResults(string lastName = null, string firstName = null,
                                   int? departmentId = null, int? subDepartmentId = null)
        {
            return await _context.EmployeeResults.FromSqlInterpolated($"SearchEmployee {lastName}, {firstName}, {departmentId}, {subDepartmentId}").ToListAsync();
        }

    }
}
