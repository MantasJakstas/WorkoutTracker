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
                WorkoutDate = createWorkoutRequest.WorkoutDate,
                WorkoutName = createWorkoutRequest.WorkoutName,
                Bodyweight = createWorkoutRequest.BodyWeight,
            };
        }

        public static GetWorkoutRequest ToWorkoutGetDto(this Workout getWorkoutRequest)
        {
            return new GetWorkoutRequest()
            {
                WorkoutName = getWorkoutRequest.WorkoutName,
                Bodyweight = getWorkoutRequest.Bodyweight,
                WorkoutId = getWorkoutRequest.WorkoutId,
                WorkoutDate = getWorkoutRequest.WorkoutDate,
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
