using Microsoft.EntityFrameworkCore;
using Test4.DataAccess.Entityes;

namespace Test4.DataAccess.Context
{
    class Test4DB : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Accountant> Accountants { get; set; }
        public DbSet<Report> Reports { get; set; }

        public Test4DB(DbContextOptions<Test4DB> options) : base(options) { }
        
    }
}
