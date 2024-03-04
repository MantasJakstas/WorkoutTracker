using backend.Dtos.Exercise;

namespace backend.Dtos.WorktoutExecrise
{
    public class GetExerciseRepetionRequest
    {
        public GetExerciseRequest Exercise { get; set; }
        public int Repetitions { get; set; }
        public int Weight { get; set; }
    }
}
