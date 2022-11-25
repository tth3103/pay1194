using Microsoft.AspNetCore.Mvc;
using Pay1194.Service.Implementation;
using Pay1194.Service;
using Microsoft.AspNetCore.Authorization;

namespace Pay1194.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPayService _payService;
        private readonly IEmployee _employeeService;
        private readonly ITaxService _taxService;
        private readonly INationalInsuranceService _nationalInsuranceService;
        private decimal overtimeHrs;
        private decimal contractualEarnings;
        private decimal overtimeEarnings;
        private decimal totalEarnings;
        private decimal tax;
        private decimal unionFee;
        private decimal studentLoan;
        private decimal nationalInsurance;
        private decimal totalDeduction;

        public PaymentController(IPayService payService, IEmployee employeeService, ITaxService taxService, INationalInsuranceService nationalInsuranceService)
        {
            _payService = payService;
            _employeeService = employeeService;
            _taxService = taxService;
            _nationalInsuranceService = nationalInsuranceService;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            //code here
            return View();
        }

        //Create CreatePaymentRecordViewModel
        //[HttpPost]
        //public IActionResult Create()
        //{
        //    //your code here
        //    return View();
        //}

        //Get Detail PaymentRecord
        [HttpGet]
        public IActionResult Detail()
        {
            //your code here
            return View();
        }

        //Get detail paysli - next week solution
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Payslip(int id)
        {
            
            return View();
        }
    }
}
