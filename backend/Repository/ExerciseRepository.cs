using backend.Constants;
using backend.Data;
using backend.Dtos.Exercise;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;
        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public CreateExerciseRequest CreateExercise(CreateExerciseRequest exerciseRequest)
        {
            _context.Exercises.Add(exerciseRequest.ToExerciseCreateDto());
            _context.SaveChanges();
            return exerciseRequest;
        }

        public GetExerciseRequest? DeleteExercise(int id)
        {
            var exercise = _context.Exercises.FirstOrDefault(e => e.ExerciseId == id);
            if (exercise == null)
            {
                return null;
            }
            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
            return exercise.ToExerciseDto();
        }

        public List<GetExerciseRequest> GetAllExercises()
        {
            var exercises = _context.Exercises.Select(e => e.ToExerciseDto()).ToList();
            return exercises;
        }

        public GetExerciseRequest? GetExercise(int id)
        {
            var exercise = _context.Exercises.FirstOrDefault(e => e.ExerciseId == id);
            if (exercise == null)
            {
                return null;
            }
            return exercise.ToExerciseDto();
        }

        public GetExerciseRequest? UpdateExercise(int id, UpdateExerciseRequest exercise)
        {
            var exerciseToUpdate = _context.Exercises.FirstOrDefault(e => e.ExerciseId == id);
            if (exerciseToUpdate == null)
            {
                return null;
            }

            exerciseToUpdate.Name = exercise.Name;
            exerciseToUpdate.MuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), exercise.MuscleGroup);
            _context.SaveChanges();
            return exerciseToUpdate.ToExerciseDto();
        }
    }
}
