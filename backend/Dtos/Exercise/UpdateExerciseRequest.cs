﻿using backend.Validation;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Exercise
{
    public class UpdateExerciseRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [ValidateMuscleGroup]
        public string MuscleGroup { get; set; } = string.Empty;
    }
}