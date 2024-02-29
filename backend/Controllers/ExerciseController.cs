using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllExercises()
        {
            Exercise exercise = new Exercise();
            exercise.Name = "Test";
            exercise.MuscleGroup = Constants.MuscleGroup.Combined;
            return Ok(exercise);
        }
    }
}
