using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class PrescriptionMedicamentEfConfig : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder
            .HasKey(x => new { x.IdPrescription, x.IdMedicament })
            .HasName("PrescriptionMedicament_pk");

        builder
            .HasOne(x => x.Prescription)
            .WithMany(x => x.Medicaments)
            .HasForeignKey(x => x.IdPrescription)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("PrescriptionMedicament_Prescription");

        builder
            .HasOne(x => x.Medicament)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.IdMedicament)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("PrescriptionMedicament_Medicament");

        builder
            .Property(x => x.Details)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .ToTable(nameof(Prescription) + "_" + nameof(Medicament));
        
        PrescriptionMedicament[] prescriptionMedicaments =
        {
            new () {IdMedicament = 1, IdPrescription = 1, Dose = 3, Details = "asdsa"},
            new () {IdMedicament = 2, IdPrescription = 2, Dose = 1, Details = "otadsd"},
            new () {IdMedicament = 2, IdPrescription = 1, Dose = 2, Details = "asdasd"},
            new () {IdMedicament = 1, IdPrescription = 3, Dose = 6, Details = "asdasd"},
        };

        builder.HasData(prescriptionMedicaments);
        
    }
}