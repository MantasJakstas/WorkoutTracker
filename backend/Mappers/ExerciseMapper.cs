using backend.Constants;
using backend.Dtos.Exercise;
using backend.Models;

namespace backend.Mappers
{
    public static class ExerciseMapper
    {
        public static Exercise ToExerciseCreateDto(this CreateExercise createExerciseRequest)
        {
            return new Exercise()
            {
                Name = createExerciseRequest.Name,
                MuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), createExerciseRequest.MuscleGroup),
            };
        }

        public static GetExercise ToExerciseDto(this Exercise exercise)
        {
            return new GetExercise()
            {
                Id = exercise.ExerciseId,
                Name = exercise.Name,
                MuscleGroup = exercise.MuscleGroup.ToString(),
            };
        }
    }
}
