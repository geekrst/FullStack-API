using Microsoft.EntityFrameworkCore;        // importing EntityFrameworkCore - since we are using DbContext
using FullStack.API.Models;

namespace FullStack.API.Data
{
    public class FullStackDbContext: DbContext      //class inheriting DbContext
    {
        //we passing options to DBContext and also passes to base classs
        public FullStackDbContext(DbContextOptions options) : base(options){}      //constructor with options parameter
        //EF core look at the DbContext (FullStackDbContext)  and will create a new table Employees
        public DbSet<Employee> Employees { get; set; }      //property of type DbSet<Employee> 
    }
    
}