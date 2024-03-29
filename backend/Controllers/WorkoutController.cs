﻿using backend.Data;
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
        public IActionResult CreateWorkout([FromBody] CreateWorkout workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Workouts.Add(workout.ToWorkoutCreateDto());
            _context.SaveChanges();
            return Ok(workout);
        }

        [Route("createWithExercises")]
        [HttpPost]
        public IActionResult CreateWorkoutWithExercises([FromBody] CreateWorkoutWithExercises workoutWithExercises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Workout workout = new Workout
            {
                WorkoutName = workoutWithExercises.WorkoutName,
                WorkoutDate = workoutWithExercises.WorkoutDate,
                Bodyweight = workoutWithExercises.BodyWeight,
            };

            _context.Workouts.Add(workout);
            _context.SaveChanges();

            foreach (var exercises in workoutWithExercises.ExercisesWithReps)
            {
                var exercise = _context.Exercises.FirstOrDefault(s => s.Name == exercises.ExerciseName);
                if (exercise == null)
                {
                    return BadRequest($"{exercises.ExerciseName}: Exercise not found");
                }
                ExerciseRepetitions exerciseRepetitions = new ExerciseRepetitions
                {
                    ExerciseId = exercise.ExerciseId,
                    WorkoutId = workout.WorkoutId,
                    Repetitions = exercises.Repetitions,
                    Weight = exercises.Weight,
                };
                _context.ExerciseRepetitions.Add(exerciseRepetitions);
            }
            _context.SaveChanges();

            return Ok(workout.ToWorkoutGetDto());
        }

        [Route("addExercises")]
        [HttpPost]
        public IActionResult AddExercisesToWorkout([FromBody] AddExercisesToWorkout exercisesWithWorkout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var workout = _context.Workouts.Find(exercisesWithWorkout.WorkoutId);

            if (workout == null)
            {
                return BadRequest("No such workout exists");
            }

            foreach (var exercises in exercisesWithWorkout.ExercisesWithReps)
            {
                var exercise = _context.Exercises.Find(exercises.ExerciseName);
                if (exercise == null)
                {
                    return BadRequest("No such exercise exists");
                }
                else
                {
                    ExerciseRepetitions exerciseRepetitions = new ExerciseRepetitions
                    {
                        ExerciseId = exercise.ExerciseId,
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
