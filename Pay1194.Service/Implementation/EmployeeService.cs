﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pay1194.Entity;
using Pay1194.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pay1194.Service.Implementation
{
    public class EmployeeService : IEmployee

    {
        private readonly ApplicationDbContext _context;
        private decimal studentLoanAmount;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Where(employee => employee.Id == id).FirstOrDefault();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = GetById(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }


        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            var employee = GetById(id);
            if (employee.StudentLoan == StudentLoan.Yes && totalAmount > 1750 && totalAmount < 2000)
            {
                studentLoanAmount = 15m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2000 && totalAmount < 2250)
            {
                studentLoanAmount = 38m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2250 && totalAmount < 2500)
            {
                studentLoanAmount = 60m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2500)
            {
                studentLoanAmount = 83m;
            }
            else
            {
                studentLoanAmount = 0m;
            }
            return studentLoanAmount;
        }

        public decimal UnionFees(int id)
        {
            var employee = GetById(id);
            var fee = employee.UnionMember == UnionMember.Yes ? 10m : 0m;
            return fee;
        }
        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.FullName,
                Value = emp.Id.ToString()
            });
        }


    }
}
