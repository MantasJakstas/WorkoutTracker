using backend.Dtos.Exercise;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IExerciseRepository
    {
        List<GetExercise> GetAllExercises();

        GetExercise? GetExercise(int id);

        GetExercise? DeleteExercise(int id);

        CreateExercise CreateExercise(CreateExercise exerciseRequest);

        GetExercise? UpdateExercise(int id, UpdateExercise exercise);
    }
}
