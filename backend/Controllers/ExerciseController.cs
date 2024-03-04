using backend.Data;
using backend.Dtos.Exercise;
using backend.Interfaces;
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
        private readonly IExerciseRepository _exerciseRepo;
        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepo = exerciseRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetExercise(int id)
        {
            var exercise = _exerciseRepo.GetExercise(id);
            if (exercise == null)
            {
                return BadRequest("No exercise found");
            }
            return Ok(exercise);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteExercise(int id)
        {
            var exercise = _exerciseRepo.DeleteExercise(id);
            if (exercise == null)
            {
                return BadRequest("No exercise found");
            }
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllExercises()
        {
            var exercises = _exerciseRepo.GetAllExercises();
            if (exercises.Count == 0)
            {
                return BadRequest("No exercises found");
            }
            return Ok(exercises);
        }

        [HttpPost]
        public IActionResult CreateExercise([FromBody] CreateExerciseRequest exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdExercise = _exerciseRepo.CreateExercise(exercise);
            return Ok(createdExercise);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateExercise([FromRoute] int id, [FromBody] UpdateExerciseRequest exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedExercise = _exerciseRepo.UpdateExercise(id, exercise);
            return Ok(updatedExercise);
        }
    }
}
