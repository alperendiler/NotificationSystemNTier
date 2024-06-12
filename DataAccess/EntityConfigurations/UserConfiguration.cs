using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Entities.Concretes;
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
            builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);


            builder.HasMany(u => u.UserOperationClaims);
            builder.HasMany(u => u.RefreshTokens);
            builder.HasMany(u => u.OtpAuthenticators);

            builder.HasData(_seeds);


        }
        public static Guid AdminId { get; } = Guid.NewGuid();
        private IEnumerable<User> _seeds
        {
            get
            {
                HashingHelper.CreatePasswordHash(
                    password: "AlperenDiler!",
                    passwordHash: out byte[] passwordHash,
                    passwordSalt: out byte[] passwordSalt
                );
                User adminUser =
                    new()
                    {
                        Id = AdminId,
                        Email = "alperendiler1@gmail.com",
                        FirstName = "Alperen",
                        LastName = "Diler",
                        UserName = "alperen",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt
                    };
                yield return adminUser;
            }
        }
    }
}
