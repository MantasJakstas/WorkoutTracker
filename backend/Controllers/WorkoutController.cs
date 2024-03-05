using backend.Data;
using backend.Dtos.Exercise;
using backend.Dtos.Workout;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WorkoutController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAllWorkouts()
        {
            var workouts = _context.Workouts.Include(w => w.ExerciseRepetitions).ThenInclude(e => e.Exercise).ToList();
            return Ok(workouts.Select(w => w.ToWorkoutGetDto()));
        }

        [HttpPost]
        public IActionResult CreateWorkout([FromBody] CreateWorkoutRequest workout)
        {

            _context.Workouts.Add(workout.ToWorkoutCreateDto());
            _context.SaveChanges();
            return Ok(workout);
        }

        [Route("exercises")]
        [HttpPost]
        public IActionResult CreateWorkoutWithExercises([FromBody] CreateWorkoutWithExercisesRequest workoutWithExercises)
        {
            Workout workout = new Workout
            {
                WorkoutName = workoutWithExercises.WorkoutName,
                WorkoutDate = workoutWithExercises.WorkoutDate,
                Bodyweight = workoutWithExercises.BodyWeight,
            };

            _context.Workouts.Add(workout);
            _context.SaveChanges();

            foreach (var exercises in workoutWithExercises.Exercises)
            {
                var exercise = _context.Exercises.Find(exercises.ExerciseId);
                if (exercise != null)
                {
                    ExerciseRepetitions exerciseRepetitions = new ExerciseRepetitions
                    {
                        ExerciseId = exercises.ExerciseId,
                        WorkoutId = workout.WorkoutId,
                        Repetitions = exercises.Repetitions,
                        Weight = exercises.Weight,
                    };
                    _context.ExerciseRepetitions.Add(exerciseRepetitions);
                }
            }
            _context.SaveChanges();

            return Ok(workout.ToWorkoutGetDto());
        }
    }
}
