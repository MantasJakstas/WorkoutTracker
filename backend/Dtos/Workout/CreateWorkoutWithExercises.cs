using backend.Dtos.Exercise;

namespace backend.Dtos.Workout
{
    public class CreateWorkoutWithExercises
    {
        public string WorkoutName { get; set; } = string.Empty;

        public int BodyWeight { get; set; }

        public DateTime WorkoutDate { get; set; } = DateTime.Now;

        public List<AddExercisesWithReps> ExercisesWithReps { get; set; } = new List<AddExercisesWithReps>();
    }
}
