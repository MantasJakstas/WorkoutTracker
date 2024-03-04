using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class ExerciseRepetitions
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!;

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; } = null!;

        public int Repetitions { get; set; }

        public int Weight { get; set; }
    }
}
