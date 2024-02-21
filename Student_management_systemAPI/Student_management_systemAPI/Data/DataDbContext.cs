using Microsoft.EntityFrameworkCore;
using Student_management_systemAPI.Models;

namespace Student_management_systemAPI.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students  { get; set; }



    }
}
