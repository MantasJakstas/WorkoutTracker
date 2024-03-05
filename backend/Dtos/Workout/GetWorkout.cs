using backend.Dtos.WorktoutExecrise;
using backend.Models;

namespace backend.Dtos.Workout
{
    public class GetWorkout
    {
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; } = string.Empty;
        public DateTime WorkoutDate { get; set; } = DateTime.Now;

        public int Bodyweight { get; set; }

        public List<GetExerciseRepetion> ExerciseReps { get; set; } = new List<GetExerciseRepetion>();

    }
}
