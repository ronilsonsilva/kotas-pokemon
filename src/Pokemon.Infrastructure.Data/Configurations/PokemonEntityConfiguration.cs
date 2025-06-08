using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokemon.Domain.Entities;

namespace Pokemon.Infrastructure.Data.Configurations
{
    public class PokemonEntityConfiguration : IEntityTypeConfiguration<PokemonEntity>
    {
        public void Configure(EntityTypeBuilder<PokemonEntity> builder)
        {
            builder.ToTable("Pokemons");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.MestrePokemonId)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.BaseExperience)
                .IsRequired();

            builder.Property(p => p.Height)
                .IsRequired();

            builder.Property(p => p.Weight)
                .IsRequired();

            builder.Property(p => p.IsDefault)
                .IsRequired();

            builder.Property(p => p.SpriteFrontDefault)
                .HasMaxLength(300);

            // Abilities (1:N)
            builder.OwnsMany(p => p.Abilities, ab =>
            {
                ab.ToTable("PokemonAbilities");
                ab.WithOwner().HasForeignKey("PokemonId");
                ab.HasKey("PokemonId", "Slot");
                ab.Property(a => a.Name).IsRequired().HasMaxLength(100);
                ab.Property(a => a.IsHidden).IsRequired();
                ab.Property(a => a.Slot).IsRequired();
            });

            // Types (1:N)
            builder.OwnsMany(p => p.Types, t =>
            {
                t.ToTable("PokemonTypes");
                t.WithOwner().HasForeignKey("PokemonId");
                t.HasKey("PokemonId", "Slot");
                t.Property(tp => tp.Name).IsRequired().HasMaxLength(50);
                t.Property(tp => tp.Slot).IsRequired();
            });

            // Stats (1:N)
            builder.OwnsMany(p => p.Stats, s =>
            {
                s.ToTable("PokemonStats");
                s.WithOwner().HasForeignKey("PokemonId");
                s.HasKey("PokemonId", "Name");
                s.Property(st => st.Name).IsRequired().HasMaxLength(50);
                s.Property(st => st.BaseStat).IsRequired();
                s.Property(st => st.Effort).IsRequired();
            });

            // Moves (1:N)
            builder.OwnsMany(p => p.Moves, m =>
            {
                m.ToTable("PokemonMoves");
                m.WithOwner().HasForeignKey("PokemonId");
                m.HasKey("PokemonId", "Name");
                m.Property(mv => mv.Name).IsRequired().HasMaxLength(100);
            });
        }
    }
}
