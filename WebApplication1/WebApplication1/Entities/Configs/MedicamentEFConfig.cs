using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class MedicamentEfConfig : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder
            .HasKey(x => x.IdMedicament)
            .HasName("Medicament_pk");

        builder
            .Property(x => x.IdMedicament)
            .ValueGeneratedNever();

        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(e => e.Type)
            .IsRequired()
            .HasMaxLength(40);
        
        builder.ToTable(nameof(Medicament));

        Medicament[] medicaments =
        {
            new () {IdMedicament = 1, Name = "APAP", Description = "na noc", Type = "przeciwbolowe" },
            new () {IdMedicament = 2, Name = "Aspirin", Description = "na glowe", Type = "przeciwzapalne" },
        };

        builder.HasData((medicaments));
    }
}