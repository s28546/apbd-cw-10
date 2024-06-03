using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class PrescriptionEfConfig : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder
            .HasKey(x => x.IdPrescription)
            .HasName("Prescription_pk");

        builder
            .Property(x => x.IdPrescription)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Date)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder
            .Property(x => x.DueDate)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder
            .HasOne(x => x.Patient)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.IdPatient)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Prescription_Patient");

        builder
            .HasOne(x => x.Doctor)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.IdDoctor)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Prescription_Doctor");

        builder
            .ToTable(nameof(Prescription));

        Prescription[] prescriptions =
        {
            new () {IdPrescription = 1, Date = new DateTime(2024,06,3), IdDoctor = 1, IdPatient = 1, DueDate = new DateTime(2024,10,1)},
            new () {IdPrescription = 2, Date = new DateTime(2024,06,1), IdDoctor = 2, IdPatient = 2, DueDate = new DateTime(2024,11,2)},
            new () {IdPrescription = 3, Date = new DateTime(2024,06,2), IdDoctor = 1, IdPatient = 2, DueDate = new DateTime(2024,12,3)},
        };

        builder.HasData(prescriptions);
    }
}