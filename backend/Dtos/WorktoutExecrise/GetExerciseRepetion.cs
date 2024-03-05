using backend.Dtos.Exercise;

namespace backend.Dtos.WorktoutExecrise
{
    public class GetExerciseRepetion
    {
        public GetExercise Exercise { get; set; } = new GetExercise();
        public int Repetitions { get; set; }
        public int Weight { get; set; }
    }
}
