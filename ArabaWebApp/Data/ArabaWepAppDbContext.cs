using ArabaWebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArabaWebApp.Data
{
    public class ArabaWepAppDbContext:DbContext
    {
        public ArabaWepAppDbContext(DbContextOptions<ArabaWepAppDbContext> options) : base(options) 
        { 
            
        }
        public DbSet<Araba> Arabalar { get; set; }
    }
}
