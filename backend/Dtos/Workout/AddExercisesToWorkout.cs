using backend.Dtos.Exercise;

namespace backend.Dtos.Workout
{
    public class AddExercisesToWorkout
    {
        public int WorkoutId { get; set; }

        public List<AddExercisesWithReps> ExercisesWithReps { get; set; } = new List<AddExercisesWithReps>();
    }
}
