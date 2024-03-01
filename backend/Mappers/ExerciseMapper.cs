using backend.Constants;
using backend.Dtos.Exercise;
using backend.Models;

namespace backend.Mappers
{
    public static class ExerciseMapper
    {
        public static Exercise ToExerciseCreateDto(this CreateExerciseRequest createExerciseRequest)
        {
            return new Exercise()
            {
                Name = createExerciseRequest.Name,
                MuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), createExerciseRequest.MuscleGroup),
            };
        }

        public static GetExerciseRequest ToExerciseDto(this Exercise exercise)
        {
            return new GetExerciseRequest()
            {
                Name = exercise.Name,
                MuscleGroup = exercise.MuscleGroup.ToString(),
            };
        }
    }
}
