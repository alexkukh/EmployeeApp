using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EmployeeApp.Models;
using System.Collections.Generic;

namespace EmployeeApp.Data;

public class AppDBContext : DbContext
{
    public AppDBContext() { }
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)	{}
    /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Data/Employees.db");
            optionsBuilder.UseSqlite($"Filename={path}", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
    }*/

	public DbSet<EmployeeDetail> Employee_Details { get; set; }
	public DbSet<EmployeeField> Employee_Fields { get; set; }
}

