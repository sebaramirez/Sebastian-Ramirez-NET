using Microsoft.EntityFrameworkCore;
using Sebastian_Ramirez_NET.Entites;

namespace Sebastian_Ramirez_NET.DTOs
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }

        public DbSet<TaskEntites> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
