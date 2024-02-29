using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ExerciseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllExercises()
        {
            Exercise exercise = new Exercise();
            exercise.Name = "Test";
            exercise.MuscleGroup = Constants.MuscleGroup.Combined;
            _context.Exercises.Add(exercise);
            return Ok(exercise);
        }
    }
}
