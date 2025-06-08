using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokemon.Domain.Entities;

namespace Pokemon.Infrastructure.Data.Configurations
{
    public class MestrePokemonConfiguration : IEntityTypeConfiguration<MestrePokemon>
    {
        public void Configure(EntityTypeBuilder<MestrePokemon> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Cpf)
                .IsRequired()
                .HasMaxLength(14);
            builder.Property(e => e.Idade)
                .IsRequired();
        }
    }
}
