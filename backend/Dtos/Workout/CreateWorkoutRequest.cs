using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Workout
{
    public class CreateWorkoutRequest
    {
        public string WorkoutName { get; set; } = string.Empty;

        [Required]
        public int BodyWeight { get; set; }
    }
}
