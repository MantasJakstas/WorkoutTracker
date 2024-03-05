using backend.Constants;
using backend.Dtos.Exercise;
using backend.Dtos.Workout;
using backend.Dtos.WorktoutExecrise;
using backend.Models;

namespace backend.Mappers
{
    public static class WorkoutMapper
    {
        public static Workout ToWorkoutCreateDto(this CreateWorkout createWorkoutRequest)
        {
            return new Workout()
            {
                WorkoutDate = createWorkoutRequest.WorkoutDate,
                WorkoutName = createWorkoutRequest.WorkoutName,
                Bodyweight = createWorkoutRequest.BodyWeight,
            };
        }

        public static GetWorkout ToWorkoutGetDto(this Workout getWorkoutRequest)
        {
            return new GetWorkout()
            {
                WorkoutName = getWorkoutRequest.WorkoutName,
                Bodyweight = getWorkoutRequest.Bodyweight,
                WorkoutId = getWorkoutRequest.WorkoutId,
                WorkoutDate = getWorkoutRequest.WorkoutDate,
                ExerciseReps = getWorkoutRequest.ExerciseRepetitions.Select(e => new GetExerciseRepetion()
                {
                    Repetitions = e.Repetitions,
                    Weight = e.Weight,
                    Exercise = e.Exercise.ToExerciseDto(),
                }).ToList()
            };
        }
    }
}
