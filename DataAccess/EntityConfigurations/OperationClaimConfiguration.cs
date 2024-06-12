using Core.Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DataAccess.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

            builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
            builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
            builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

            builder.HasData(_seeds);
        }

        public static int AdminId => 1;

        private IEnumerable<OperationClaim> _seeds
        {
            get
            {
                yield return new OperationClaim { Id = AdminId, Name = "Admin", CreatedDate = DateTime.UtcNow };

                var featureOperationClaims = getFeatureOperationClaims(AdminId);
                foreach (var claim in featureOperationClaims)
                {
                    yield return claim;
                }
            }
        }

        private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
        {
            int lastId = initialId;
            List<OperationClaim> featureOperationClaims = new List<OperationClaim>();

            featureOperationClaims.AddRange(new[]
            {
                new OperationClaim { Id = ++lastId, Name = "Auth.Admin", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "Auth.Read", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "Auth.Write", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "Auth.RevokeToken", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "OperationClaims.Admin", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "OperationClaims.Read", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "OperationClaims.Write", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "OperationClaims.Create", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "OperationClaims.Update", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "OperationClaims.Delete", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "UserOperationClaims.Admin", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "UserOperationClaims.Read", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "UserOperationClaims.Write", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "UserOperationClaims.Create", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "UserOperationClaims.Update", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "UserOperationClaims.Delete", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "Users.Admin", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "Users.Read", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "Users.Write", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "Users.Create", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "Users.Update", CreatedDate = DateTime.UtcNow },
                new OperationClaim { Id = ++lastId, Name = "Users.Delete", CreatedDate = DateTime.UtcNow },
            });

            return featureOperationClaims;
        }
    }
}
