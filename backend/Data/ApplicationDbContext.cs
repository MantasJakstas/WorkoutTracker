using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseRepetitions> ExerciseRepetitions { get; set; }

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseRepetitions>().HasKey(e => new { e.ExerciseId, e.WorkoutId });

            modelBuilder.Entity<ExerciseRepetitions>()
                .HasOne(we => we.Exercise)
                .WithMany(w => w.ExerciseRepetitions)
                .HasForeignKey(we => we.ExerciseId);

            modelBuilder.Entity<ExerciseRepetitions>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.ExerciseRepetitions)
                .HasForeignKey(we => we.WorkoutId);

        }

    }
}
