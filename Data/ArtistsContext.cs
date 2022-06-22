using Microsoft.EntityFrameworkCore;
using ScaffoldDB.Entities;

namespace ScaffoldDB.Data
{
    public partial class ArtistsContext : DbContext
    {
        public ArtistsContext()
        {
        }

        public ArtistsContext(DbContextOptions<ArtistsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Studio> Studios { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("data source=output/Artists.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Albums)
                    .UsingEntity<Dictionary<string, object>>(
                        "AlbumTag",
                        l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                        r => r.HasOne<Album>().WithMany().HasForeignKey("AlbumId"),
                        j =>
                        {
                            j.HasKey("AlbumId", "TagId");

                            j.ToTable("AlbumTags");
                        });
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Studio)
                    .HasForeignKey<Studio>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}



















