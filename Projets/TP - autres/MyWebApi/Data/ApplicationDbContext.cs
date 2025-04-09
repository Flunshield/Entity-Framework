using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructeur pour injecter les options de configuration
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Définir les DbSets pour tes entités
        public DbSet<User> Users { get; set; }
    }
}