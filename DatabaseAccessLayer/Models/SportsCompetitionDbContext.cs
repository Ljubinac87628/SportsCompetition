using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseAccessLayer
{
    public partial class SportsCompetitionDbContext : DbContext
    {
        public SportsCompetitionDbContext()
        {
        }

        public SportsCompetitionDbContext(DbContextOptions<SportsCompetitionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionMember> CompetitionMembers { get; set; }
        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserGroupRole> UserGroupRoles { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VDDSJFA\\SQLEXPRESS;Initial Catalog=SportsCompetition;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasOne(d => d.CompetitionOrganizer)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.CompetitionOrganizerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competition_AspNetUser");

                entity.HasOne(d => d.CompetitionType)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.CompetitionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competition_CompetitionType");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competition_Venue");
            });

            modelBuilder.Entity<CompetitionMember>(entity =>
            {
                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompetitionMembers)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitionMember_Competition");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CompetitionMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitionMember_AspNetUser");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<UserGroupRole>(entity =>
            {
                entity.HasKey(e => new { e.UserGroupId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserGroupRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserGroupRoles_AspNetRoles");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.UserGroupRoles)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserGroupRoles_UserGroups");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Venues)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venue_Country");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
