using Microsoft.EntityFrameworkCore;

namespace PlannerAPI.Models
{
    public partial class PlannerDBContext : DbContext
    {
        public PlannerDBContext()
        {
        }

        public PlannerDBContext(DbContextOptions<PlannerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.ToTable("TodoItem");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Task)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
