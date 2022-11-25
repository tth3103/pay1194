using Microsoft.AspNetCore.Mvc.Rendering;
using Pay1194.Entity;
using Pay1194.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay1194.Service.Implementation
{
    public class PayService : IPayService

    {
        private decimal contractualEarning;
        public decimal overtimeHours;
        public readonly ApplicationDbContext _context;
        public PayService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {

            if (hoursWorked < contractualHours)
            {
                contractualEarning = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarning = contractualHours * hourlyRate;
            }
            return contractualEarning;
        }

        public Task CreateAsync(PaymentRecord paymentRecord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            throw new NotImplementedException();
        }

        public PaymentRecord GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TaxYear GetTaxYearById(int id)
        {
            throw new NotImplementedException();
        }

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
        {
            throw new NotImplementedException();
        }

        public decimal OverTimeEarnings(decimal overtimeRate, decimal overtimeHours)
        {
            return overtimeHours * overtimeRate;
        }

        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if(hoursWorked <= contractualHours)
            {
                overtimeHours = 0.00m;
            }
            else
            {
                overtimeHours = hoursWorked - contractualHours;
            }
            return overtimeHours;
        }

        public decimal OverTimerate(decimal hourlyRate)
        {
            return hourlyRate * 1.5m;
        }

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal UnionFees)
        {
            return tax + UnionFees + studentLoanRepayment + nic;
        }

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
        {
            return overtimeEarnings + contractualEarnings;
        }
    }
}
