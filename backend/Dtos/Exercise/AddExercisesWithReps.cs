using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Exercise
{
    public class AddExercisesWithReps
    {
        [Required]
        public string ExerciseName { get; set; } = null!;
        [Required]
        public int Repetitions { get; set; }
        public int Weight { get; set; }
    }
}
