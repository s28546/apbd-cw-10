using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Utilities;

namespace WebApplication1.Entities.Configs;

public class UserEfConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(x => x.IDUser)
            .HasName("User_pk");
        
        builder
            .Property(x => x.IDUser)
            .ValueGeneratedNever();
        
        builder
            .Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(64);
        
        builder
            .Property(x => x.RefreshToken)
            .HasMaxLength(64);

        builder.ToTable(nameof(User));
        
        User[] users =
        {
            new User
            {
                IDUser = 1,
                Username = "Jan",
                Password = PasswordUtils.HashPassword("pass123"),
                RefreshToken = "token1"
            },
            new User
            {
                IDUser = 2,
                Username = "Adam",
                Password= PasswordUtils.HashPassword("pass456"), 
                RefreshToken = "token2"
            }
        };

        builder.HasData(users);
    }
}