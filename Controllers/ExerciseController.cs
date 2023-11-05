using AssistantCoachAPI.Models;
namespace AssistantCoachAPI.Controllers;
using Microsoft.EntityFrameworkCore;
public class ExerciseController{
    public static void Map(WebApplication app){
        app.MapGet("/exercises", async (ExerciseDb db) => await db.Exercises.ToListAsync());
        app.MapGet("/exercises/{id}", async (ExerciseDb db, int id) => await db.Exercises.FindAsync(id));
        app.MapPost("/exercises", async (ExerciseDb db, Exercise exercise) => 
        {
            await db.Exercises.AddAsync(exercise);
            await db.SaveChangesAsync();
            return Results.Created($"/exercises/{exercise.Id}", exercise);
        });
        app.MapPut("/exercises/{id}", async (ExerciseDb db, int id, Exercise exercise) =>
        {
            var exerciseToUpdate = await db.Exercises.FindAsync(id);
            if (exerciseToUpdate == null) return Results.NotFound();
            exerciseToUpdate.Name = exercise.Name;
            exerciseToUpdate.Qt = exercise.Qt;
            await db.SaveChangesAsync();
            return Results.Created($"/exercises/{exercise.Id}", exercise);
        });
        app.MapDelete("/exercises/{id}", async (ExerciseDb db, int id) =>
        {
            var exerciseToDelete = await db.Exercises.FindAsync(id);
            if (exerciseToDelete == null) return Results.NotFound();
            db.Exercises.Remove(exerciseToDelete);
            await db.SaveChangesAsync();
            return Results.Ok();            
        });

    }
}
