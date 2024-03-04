using backend.Constants;
using backend.Dtos.Exercise;
using backend.Dtos.Workout;
using backend.Dtos.WorktoutExecrise;
using backend.Models;

namespace backend.Mappers
{
    public static class WorkoutMapper
    {
        public static Workout ToWorkoutCreateDto(this CreateWorkoutRequest createWorkoutRequest)
        {
            return new Workout()
            {
                Bodyweight = createWorkoutRequest.BodyWeight,

            };
        }

        public static GetWorkoutRequest ToWorkoutGetDto(this Workout getWorkoutRequest)
        {
            return new GetWorkoutRequest()
            {
                Bodyweight = getWorkoutRequest.Bodyweight,
                WorkoutId = getWorkoutRequest.WorkoutId,
                WorkoutName = getWorkoutRequest.WorkoutName,
                ExerciseReps = getWorkoutRequest.ExerciseRepetitions.Select(e => new GetExerciseRepetionRequest()
                {
                    Repetitions = e.Repetitions,
                    Weight = e.Weight,
                    Exercise = e.Exercise.ToExerciseDto(),
                }).ToList()
            };
        }
    }
}
