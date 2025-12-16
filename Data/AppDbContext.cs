using Microsoft.EntityFrameworkCore;
using DrugInfo.Api.Entities;

namespace DrugInfo.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DrugIngredient> DrugIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrugIngredient>()
                .HasKey(di => new { di.DrugId, di.IngredientId });
        }
    }
}
