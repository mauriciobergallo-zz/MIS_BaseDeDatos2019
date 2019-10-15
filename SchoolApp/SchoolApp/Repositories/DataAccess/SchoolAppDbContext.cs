using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Repositories.DataAccess
{
    public class SchoolAppDbContext : DbContext
    {
        public DbSet<DTO.StudentDto> Students { get; set; }
        
        public SchoolAppDbContext()
        {
        }

        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options)
            : base(options)
        {

        }
    }
}