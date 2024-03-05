using backend.Data;
using backend.Dtos.Workout;
using backend.Dtos.WorktoutExecrise;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutExerciseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WorkoutExerciseController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetWorkoutExercise()
        {
            var we = _context.ExerciseRepetitions.Include(e => e.Exercise).ToList();
            return Ok(we);
        }

        [HttpPost]
        public IActionResult CreateWorkoutExercise(int workoutId, int exerciseId, [FromBody] CreateWorkoutExercise workoutExerciseRequest)
        {
            var workout = _context.Workouts.Find(workoutId);
            var exercise = _context.Exercises.Find(exerciseId);

            ExerciseRepetitions workoutExercise1 = new ExerciseRepetitions
            {
                Repetitions = workoutExerciseRequest.Repetitions,
                ExerciseId = exerciseId,
                WorkoutId = workoutId,
            };

            _context.ExerciseRepetitions.Add(workoutExercise1);
            _context.SaveChanges();
            return Ok(workoutExercise1);
        }
    }
}
