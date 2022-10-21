using Microsoft.AspNetCore.Mvc;
using Pay1194.Entity;
using Pay1194.Models;
using Pay1194.Service;

namespace Pay1194.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public EmployeeController(IEmployee employeeService, IWebHostEnvironment hostEnvironment)
        {
            _employeeService = employeeService;
            _hostEnvironment = hostEnvironment;
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
            }).ToList();
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
                Email = employee.Email,
                Phone = employee.Phone
            };
            return View(model);

        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MidleName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Email = model.Email,
                    Phone = model.Phone,
                    DOB = model.DOB,
                    DateJoined = model.DateJoined,
                    Designation = model.Designation,
                    NationalInsuranceNo = model.NationalInsuranceNo,
                    StudentLoan = model.StudentLoan,
                    UnionMember = model.UnionMember,
                    Address = model.Address,
                    City = model.City,
                    PostCode = model.Postcode
                };
                if(model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employess";
                    var filename = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webrootPath = _hostEnvironment.WebRootPath;
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + extension;
                    var path =Path.Combine(webrootPath, uploadDir, filename);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + filename;
                }
                await _employeeService.CreateAsync(employee);
                return RedirectToAction("Index");
                
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if(employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDeleteViewModel
            {
                Id = employee.Id,
                FullName = employee.FullName
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            await _employeeService.DeleteAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
