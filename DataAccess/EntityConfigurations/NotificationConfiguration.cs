using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(b => b.Content).HasColumnName("Content").IsRequired();
            builder.Property(b => b.IsRead).HasColumnName("IsRead").IsRequired();

            builder.HasOne(v => v.User).WithMany().HasForeignKey(v => v.UserId);

        }
    }
}
