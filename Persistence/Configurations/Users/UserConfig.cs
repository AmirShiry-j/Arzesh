using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Users
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(50);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.UserType).IsRequired();

            //
            builder.Property(p => p.TimeCreate).HasDefaultValueSql("getdate()");
        }
    }
}
