using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Organization> Organizatons { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.FileID);
                entity.Property(e => e.TeamID).IsRequired();
                entity.Property(e => e.FileName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.FileName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.FileName).IsRequired();

                entity.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberID);
                entity.Property(e => e.OrganizationID).IsRequired();
                entity.Property(e => e.MemberName).HasMaxLength(20).IsRequired();
                entity.Property(e => e.MemberSurname).HasMaxLength(50).IsRequired();
                entity.Property(e => e.MemberNickName).HasMaxLength(20);

                entity.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID);
                entity.HasMany(e => e.Memberships).WithOne(e => e.Member);
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasKey(e => new { e.MemberID, e.TeamID });
                entity.Property(e => e.MembershipDate).IsRequired();

                entity.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamID);
                entity.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.OrganizationID);
                entity.Property(e => e.OrganizationName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.OrganizationDomain).HasMaxLength(50).IsRequired();

                entity.HasMany(e => e.Members).WithOne(e => e.Organization);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamID);
                entity.Property(e => e.OrganizationID).IsRequired();
                entity.Property(e => e.TeamName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.TeamDescription).HasMaxLength(500);

                entity.HasMany(e => e.Files).WithOne(e => e.Team);
                entity.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);
                entity.HasMany(e => e.Memberships).WithOne(e => e.Team);
            });

        }
    }
}
