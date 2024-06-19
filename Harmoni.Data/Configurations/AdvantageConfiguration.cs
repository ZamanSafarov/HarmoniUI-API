using Harmoni.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Data.Configurations
{
    public class AdvantageConfiguration : IEntityTypeConfiguration<Advantage>
    {
        public void Configure(EntityTypeBuilder<Advantage> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired();
            builder.Property(x => x.Icon).IsRequired();
        }
    }
}
