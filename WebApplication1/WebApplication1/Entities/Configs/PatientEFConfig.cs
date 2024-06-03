using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class PatientEfConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .HasKey(x => x.IdPatient)
            .HasName("Patient_pk");

        builder
            .Property(x => x.IdPatient)
            .ValueGeneratedNever();

        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(20);
        builder
            .Property(x => x.BirthDate)
            .IsRequired();

        builder.ToTable(nameof(Patient));

        Patient[] patients =
        {
            new() { IdPatient = 1, FirstName = "Tomasz", LastName = "Problem", BirthDate = new DateTime(2002,09,21) },
            new() { IdPatient = 2, FirstName = "Adam", LastName = "Malysz", BirthDate = new DateTime(1990,04,14) },
        };

        builder.HasData(patients);
    }
}