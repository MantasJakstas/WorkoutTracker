﻿using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Exercise
{
    public class GetExercise
    {
        public string Name { get; set; } = string.Empty;
        public string MuscleGroup { get; set; } = string.Empty;
    }
}