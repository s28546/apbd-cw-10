using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class DoctorEfConfig : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder
            .HasKey(x => x.IDdoctor)
            .HasName("Doctor_pk");
        
        builder
            .Property(x => x.IDdoctor)
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
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(40);

        builder.ToTable(nameof(Doctor));

        Doctor[] doctors =
        {
            new() {IDdoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jankowalski@gmail.com"},
            new() {IDdoctor = 2, FirstName = "Adam", LastName = "Malysz", Email = "adammalysz@gmail.com"},
        };

        builder.HasData(doctors);
    }
}