using Microsoft.EntityFrameworkCore;
using Samachar.Data.SqlServer.Configuration;
using Samachar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samachar.Data.SqlServer
{
    public class SamacharDbContext : DbContext//, IApplicationDbContext
    {
        public SamacharDbContext(DbContextOptions<SamacharDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        }

        public virtual DbSet<Article> Articles { get; set; }
    }
}
