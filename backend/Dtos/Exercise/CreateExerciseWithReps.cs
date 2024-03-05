namespace backend.Dtos.Exercise
{
    public class CreateExerciseWithReps
    {
        public int ExerciseId { get; set; }
        public int Repetitions { get; set; }
        public int Weight { get; set; }
    }
}
