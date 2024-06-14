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
    public class FAQConfiguration:IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.Property(x => x.Answer).IsRequired();
            builder.Property(x => x.Question).IsRequired();
        }
    }
}
