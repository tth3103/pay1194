using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pay1194.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay1194.Service
{
    public interface IPayService
    {
        Task CreateAsync(PaymentRecord paymentRecord);
        PaymentRecord GetById(int id);
        TaxYear GetTaxYearById(int id);
        IEnumerable<PaymentRecord> GetAll();
        IEnumerable<SelectListItem> GetAllTaxYear();
        decimal OverTimeHours(decimal hoursWorked, decimal contractualHours);
        decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);
        decimal OverTimerate(decimal hourlyRate);
        decimal OverTimeEarnings(decimal overtimeEarnings, decimal contractualEarnings);
        decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings);
        decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal UnionFees);
        decimal NetPay(decimal totalEarnings, decimal totalDeduction);
    }
}
