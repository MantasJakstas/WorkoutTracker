using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class WorkoutExercise
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!;

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; } = null!;

        [Range(0, 1000)]
        public int Repetitions { get; set; }

        public DateTime WorkoutDate { get; set; }

    }
}
