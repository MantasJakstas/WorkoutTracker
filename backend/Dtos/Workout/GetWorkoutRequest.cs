using backend.Dtos.WorktoutExecrise;
using backend.Models;

namespace backend.Dtos.Workout
{
    public class GetWorkoutRequest
    {
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; } = string.Empty;

        public int Bodyweight { get; set; }

        public List<GetExerciseRepetionRequest> ExerciseReps { get; set; }

    }
}
