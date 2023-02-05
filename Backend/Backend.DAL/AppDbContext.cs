using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class AppDbContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Tranzactie> Tranzactii { get; set; }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });
            modelBuilder.Entity<User>()
                .HasMany(c => c.Cards)
                .WithOne(u => u.User);
            modelBuilder.Entity<Tranzactie>()
                .HasOne(a => a.User)
                .WithMany(b => b.Tranzactii);
            modelBuilder.Entity<Card>()
                .HasOne(a => a.User)
                .WithMany(b => b.Cards);
            modelBuilder.Entity<Friend>()
                .HasOne(a => a.User)
                .WithMany(b => b.Friends);

        }

    }
}
