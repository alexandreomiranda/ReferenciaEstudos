using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginWebFormsMVC.Models
{
    public class AccessContext : DbContext
    {
        public AccessContext()
            : base("DBAcesso")
        {

        }

        public virtual DbSet<Role> RoleSet { get; set; }
        public virtual DbSet<Login> LoginSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Role>()
                   .HasMany<Login>(o => o.Logins)
                   .WithMany(o => o.Roles)
                   .Map(rl =>
                   {
                       rl.MapLeftKey("RoleId");
                       rl.MapRightKey("LoginId");
                       rl.ToTable("RoleLogin");
                   });
        }
    }
}