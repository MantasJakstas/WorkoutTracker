using backend.Data;
using backend.Dtos.Exercise;
using backend.Mappers;
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
            List<GetExerciseRequest> exercises = _context.Exercises.Select(e => e.ToExerciseDto()).ToList();
            return Ok(exercises);
        }

        [HttpPost]
        public IActionResult CreateExercise([FromBody] CreateExerciseRequest exercise)
        {
            _context.Exercises.Add(exercise.ToExerciseCreateDto());
            _context.SaveChanges();
            return Ok(exercise);
        }
    }
}
