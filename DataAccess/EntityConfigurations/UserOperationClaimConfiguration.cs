﻿using Core.Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

            builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
            builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
            builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

            builder.HasOne(uoc => uoc.User)
                   .WithMany()
                   .HasForeignKey(uoc => uoc.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uoc => uoc.OperationClaim)
                   .WithMany()
                   .HasForeignKey(uoc => uoc.OperationClaimId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(_seeds);
        }

        private IEnumerable<UserOperationClaim> _seeds
        {
            get
            {
                yield return new UserOperationClaim
                {
                    Id = Guid.NewGuid(),
                    UserId = UserConfiguration.AdminId,
                    OperationClaimId = OperationClaimConfiguration.AdminId,
                    CreatedDate = DateTime.UtcNow
                };
            }
        }
    }
}
