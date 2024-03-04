using backend.Dtos.Exercise;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IExerciseRepository
    {
        List<GetExerciseRequest> GetAllExercises();

        GetExerciseRequest? GetExercise(int id);

        GetExerciseRequest? DeleteExercise(int id);

        CreateExerciseRequest CreateExercise(CreateExerciseRequest exerciseRequest);

        GetExerciseRequest? UpdateExercise(int id, UpdateExerciseRequest exercise);
    }
}
