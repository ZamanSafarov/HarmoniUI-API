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
	public class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
	{
		public void Configure(EntityTypeBuilder<Speaker> builder)
		{
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Experience).IsRequired();
		}
	}
}
