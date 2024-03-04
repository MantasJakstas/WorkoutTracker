using backend.Data;
using backend.Dtos.Exercise;
using backend.Dtos.Workout;
using backend.Interfaces;
using backend.Mappers;
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
    }
}
