namespace backend.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; } = string.Empty;
        public int Bodyweight { get; set; }

        public DateTime WorkoutDate { get; set; } = DateTime.Now;
        public List<ExerciseRepetitions> ExerciseRepetitions { get; set; } = new List<ExerciseRepetitions>();

    }
}
