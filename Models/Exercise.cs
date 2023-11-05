using Microsoft.EntityFrameworkCore;

namespace AssistantCoachAPI.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string? Name {get; set;}
        public string? Qt {get; set;}
    }

    class ExerciseDb : DbContext
    {
        public ExerciseDb(DbContextOptions options) : base(options) {}
        public DbSet<Exercise> Exercises {get; set;} = null!;
    }
}