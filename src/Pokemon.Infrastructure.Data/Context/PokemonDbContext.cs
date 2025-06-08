using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Entities;
using Pokemon.Infrastructure.Data.Configurations;

namespace Pokemon.Infrastructure.Data.Context
{
    public class PokemonDbContext : DbContext
    {
        public DbSet<MestrePokemon> MestresPokemon { get; set; }
        public DbSet<PokemonEntity> Pokemons { get; set; }

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MestrePokemonConfiguration());
            modelBuilder.ApplyConfiguration(new PokemonEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
