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
	public class SettingConfiguration : IEntityTypeConfiguration<Setting>
	{
		public void Configure(EntityTypeBuilder<Setting> builder)
		{
			builder.Property(x=>x.Key).IsRequired().HasMaxLength(256);
			builder.Property(x=>x.Value).IsRequired().HasMaxLength(256);
		}
	}
}
