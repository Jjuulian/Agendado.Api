using AgendadoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendadoApi.Data
{
    public class AgendaDbContext : DbContext
    {
        public AgendaDbContext(DbContextOptions<AgendaDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Event>()
                .HasOne<User>()
                .WithMany(u => u.Events)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Events");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.StartEventDate).HasColumnName("start_datetime");
                entity.Property(e => e.EndEventDate).HasColumnName("end_datetime");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.Category).HasColumnName("category_id");

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId).HasColumnName("UserId");
                entity.Property(u => u.Name).HasColumnName("Name");
                entity.Property(u => u.Surname).HasColumnName("Surname");
                entity.Property(u => u.Surname2).HasColumnName("Surname2");
                entity.Property(u => u.BirthDate).HasColumnName("BirthDate");
                entity.Property(u => u.Email).HasColumnName("Email");
                entity.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                entity.Property(u => u.CreatedAt).HasColumnName("CreatedAt");
                entity.Property(u => u.UpdatedAt).HasColumnName("UpdatedAt");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CategoryName).HasColumnName("name");
            });
        }
    }
}

