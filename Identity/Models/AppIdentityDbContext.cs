using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Identity.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }
        public DbSet<User>? User { get; set; }
        public DbSet<Report>? Reports { get; set; }

        public DbSet<ManagerAuthority>? ManagerAuthorities { get; set; }
        public DbSet<EngineerSupervisor>? EngineerSupervisors { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<Approval>? Approvals { get; set; }
        public DbSet<Stage>? Stages { get; set; }
        public DbSet<Tasks>? Tasks { get; set; }
        public DbSet<Cost>? Costs { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<Quote>? Quotes { get; set; }
        
    }

}