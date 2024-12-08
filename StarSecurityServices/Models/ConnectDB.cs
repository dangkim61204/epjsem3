using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Principal;

namespace StarSecurityServices.Models
{
    public class ConnectDB: DbContext
    {
        public ConnectDB() { }
        public ConnectDB(DbContextOptions<ConnectDB> options)
            : base(options)
        {

        }
        //khai báo các thuộc tính map với bảng
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Branche> Branches { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Vacancie> Vacancies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientEmployee> clientEmployees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ nhiều-nhiều
            modelBuilder.Entity<ClientEmployee>()
                .HasKey(ce => ce.Id);

            modelBuilder.Entity<ClientEmployee>()
                .HasOne(ce => ce.Client)
                .WithMany(c => c.ClientEmployees)
                .HasForeignKey(ce => ce.ClientId);

            modelBuilder.Entity<ClientEmployee>()
                .HasOne(ce => ce.Employee)
                .WithMany(e => e.ClientEmployees)
                .HasForeignKey(ce => ce.EmployeeId);
        }
    }

}
