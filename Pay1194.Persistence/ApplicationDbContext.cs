using Microsoft.EntityFrameworkCore;
using Pay1194.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay1194.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
        public DbSet<TaxYear> TaxYears { get; set; }
    }
}
