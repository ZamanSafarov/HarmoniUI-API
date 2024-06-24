using Harmoni.Core.Entities;
using Harmoni.Core.Identity;
using Harmoni.Data.Configurations;
using Harmoni.Data.RepConcretes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Data.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<FAQContent> FAQContents { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SettingConfiguration).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
