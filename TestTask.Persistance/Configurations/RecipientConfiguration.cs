using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TestTask.Domain;

namespace TestTask.Persistance.Configurations
{
    public class RecipientConfiguration : IEntityTypeConfiguration<Recipient>
    {
        public void Configure(EntityTypeBuilder<Recipient> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(i => i.Id).IsUnique();
            builder.HasMany(i => i.Packages)
                .WithOne(j => j.Recipient)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
