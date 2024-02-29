using backend.Constants;

namespace backend.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public MuscleGroup MuscleGroup {  get; set; } 
        public List<WorkoutExercise> WorkoutExercise { get; set;} = new List<WorkoutExercise>();
    }
}
