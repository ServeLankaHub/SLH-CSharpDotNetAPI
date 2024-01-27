using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using serveSLhub.Entities;
using System.Reflection.Emit;

namespace serveSLhub.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>()
                .HasIndex(gn => gn.UserId)
                .IsUnique(); // Set GramaNiladhariId as unique 

            builder.Entity<PersonDetails>()
        .HasOne(pd => pd.GN_Division)
        .WithMany()
        .HasForeignKey(pd => pd.DivisionID)
        .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PersonDetails>()
        .HasOne(pd => pd.GN_Division)
        .WithMany()
        .HasForeignKey(pd => pd.DivisionID)
        .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }


        public DbSet<Users>? users { get; set; }
        public DbSet<GN_Division>? gN_Divisions { get; set; }

        public DbSet<PersonDetails>? personDetails { get; set; }
        public DbSet<Family>? families { get; set; }
        public DbSet<Family_Members>? familyMembers { get; set; }
    }
}
