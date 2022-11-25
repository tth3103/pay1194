using Microsoft.AspNetCore.Mvc.Rendering;
using Pay1194.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pay1194.Persistence;

namespace Pay1194.Service.Implementation
{
    public class PayService : IPayService
    {
        private decimal contractualEarnings;
        private decimal overtimeHours;
        private readonly ApplicationDbContext _context;
        public PayService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if(hoursWorked < contractualHours)
            {
                contractualEarnings=hoursWorked*hourlyRate;
            }
            else
            {
                contractualEarnings =contractualEarnings*hourlyRate;
            }
            return contractualEarnings;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _context.PaymentRecords.AddAsync(paymentRecord);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords.OrderBy(p => p.EmployeeId).ToList();

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(taxYear => new SelectListItem
            {
                Text = taxYear.YearOfTax,
                Value = taxYear.Id.ToString()
            });
            return allTaxYear;
        }

        public PaymentRecord GetById(int id) =>_context.PaymentRecords.Where(pay=>pay.Id==id).FirstOrDefault();

        public TaxYear GetTaxYearById(int id) =>_context.TaxYears.Where(year=>year.Id==id).FirstOrDefault();

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction) => totalEarnings - totalDeduction;

        public decimal OverTimeEarnings(decimal overtimeRate, decimal overtimeHours) =>overtimeHours*overtimeRate;

        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if (hoursWorked <= contractualHours) 
            {
                overtimeHours = 0.0m;
            } 
            else if(hoursWorked > contractualHours)
            {
                overtimeHours =hoursWorked * contractualHours;
            }
            return overtimeHours;
        }

        public decimal OverTimerate(decimal hourlyRate) => hourlyRate * 1.5m;

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal UnionFees) => tax + nic+studentLoanRepayment+UnionFees;

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings) => overtimeEarnings + contractualEarnings;
    }
}
