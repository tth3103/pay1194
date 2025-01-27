﻿using Pay1194.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pay1194.Models
{
    public class PaymentRecordIndexViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [Display(Name ="Name")]
        public string FullName { get; set; }
        [Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }
        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; }
        public int TaxYearId { get; set; }
        public string Year { get; set; }
        [Display(Name ="Total Earnings")]
        public decimal TotalEarnings { get; set; }
        [Display(Name = "Total Deduction")]
        public decimal TotalDeduction { get; set; }
        [Display(Name = "Net")]
        public decimal NetPayment { get; set; }
    }
}
