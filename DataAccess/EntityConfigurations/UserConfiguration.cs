using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.UserName).HasColumnName("UserName").IsRequired();
            builder.Property(b => b.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(b => b.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(b => b.Email).HasColumnName("Email").IsRequired();
            builder.Property(b => b.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            builder.Property(b => b.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(b => b.Status).HasColumnName("Status");


        }
    }
}
