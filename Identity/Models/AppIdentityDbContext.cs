using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Identity.Models;

namespace Identity.Models
{

    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<Ledgers> Ledgers { get; set; }
        //public DbSet<Stock> Stocks { get; set; }
        //public DbSet<Item> Items { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<EmployeeInfo> EmployeesInfo { get; set; }
        //public DbSet<OldEmployeeInfo> OldEmployeesInfo { get; set; }
    }





}