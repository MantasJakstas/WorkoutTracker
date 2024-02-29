namespace backend.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public int Bodyweight { get; set; }
        public List<WorkoutExercise> WorkoutExercise { get; set; } = new List<WorkoutExercise>();

    }
}
