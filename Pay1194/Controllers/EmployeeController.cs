using Microsoft.AspNetCore.Mvc;
using Pay1194.Models;
using Pay1194.Service;

namespace Pay1194.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;
        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var model = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                ImageUrl = employee.ImageUrl,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                City = employee.City
            });
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            var model = new EmployeeDetailViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                ImageUrl = employee.ImageUrl,
                DOB = employee.DOB,
                Designation = employee.Designation,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                UnionMember = employee.UnionMember,
                StudentLoan = employee.StudentLoan,
                City = employee.City,
                PostCode = employee.PostCode,
                Email = employee.Email
            };
            return View(model);

        }
    }
}
