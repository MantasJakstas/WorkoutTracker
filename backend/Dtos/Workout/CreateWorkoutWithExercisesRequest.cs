using backend.Dtos.Exercise;

namespace backend.Dtos.Workout
{
    public class CreateWorkoutWithExercisesRequest
    {
        public string WorkoutName { get; set; } = string.Empty;

        public int BodyWeight { get; set; }

        public DateTime WorkoutDate { get; set; } = DateTime.Now;

        public List<CreateExerciseWithReps> Exercises { get; set; } = new List<CreateExerciseWithReps>();
    }
}
