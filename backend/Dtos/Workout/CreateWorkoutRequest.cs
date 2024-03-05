﻿using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Workout
{
    public class CreateWorkoutRequest
    {
        public string WorkoutName { get; set; } = string.Empty;

        public int BodyWeight { get; set; }

        public DateTime WorkoutDate { get; set; } = DateTime.Now;

    }
}
