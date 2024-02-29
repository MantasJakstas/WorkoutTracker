using backend.Constants;

namespace backend.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public MuscleGroup MuscleGroup {  get; set; } 
    }
}
