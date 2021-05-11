using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeContext _dbContext;

        public HomeController(ILogger<HomeController> logger, EmployeeContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(string lastName = null, string firstName = null,
                                   int? departmentId = null, int? subDepartmentId = null)
        {
            lastName = (lastName == null || lastName.Trim() == "") ? null : lastName.Trim();
            firstName = (firstName == null || firstName.Trim() == "") ? null : firstName.Trim();

            ViewData["deptList"] = new SelectList(_dbContext.Departments.ToList(), "DepartmentID", "DepartmentName");
            ViewData["subDeptList"] = new SelectList(_dbContext.SubDepartments.ToList(), "SubDepartmentID", "SubDepartmentName");

            var employeeList = _dbContext.EmployeeResults.FromSqlInterpolated($"SearchEmployee {lastName}, {firstName}, {departmentId}, {subDepartmentId}").ToList();
            return View(employeeList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
