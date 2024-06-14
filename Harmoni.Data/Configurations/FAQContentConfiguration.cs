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
    public class FAQContentConfiguration : IEntityTypeConfiguration<FAQContent>
    {
        public void Configure(EntityTypeBuilder<FAQContent> builder)
        {

            builder.Property(x => x.Name).IsRequired();
        }
    }
}
