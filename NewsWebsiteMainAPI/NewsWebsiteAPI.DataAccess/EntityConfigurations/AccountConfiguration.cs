using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.EntityConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasKey(account => account.Id);

            builder
                .Property(account => account.RoleId)
                .IsRequired();
            builder
                .Property(account => account.FullName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(account => account.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(account => account.PasswordHash)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}