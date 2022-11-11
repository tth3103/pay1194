using Microsoft.AspNetCore.Mvc.Rendering;
using Pay1194.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay1194.Service.Implementation
{
    public class PayService : IPayService
    {
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            throw new NotImplementedException();
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

        public decimal OverTimeEarnings(decimal overtimeEarnings, decimal contractualEarnings)
        {
            throw new NotImplementedException();
        }

        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
            throw new NotImplementedException();
        }

        public decimal OverTimerate(decimal hourlyRate)
        {
            throw new NotImplementedException();
        }

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal UnionFees)
        {
            throw new NotImplementedException();
        }

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
        {
            throw new NotImplementedException();
        }
    }
}
