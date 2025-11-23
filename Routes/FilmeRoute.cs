using CinemaPipocando.Requests;
using CinemaPipocando.Data;
using Microsoft.EntityFrameworkCore;
using CinemaPipocando.Models;
namespace CinemaPipocando.Routes;

public static class FilmeRoute
{
    public static void FilmeRoutes(this WebApplication app)
    {
        var route = app.MapGroup("filmes");

        route.MapPost("", 
            async (FilmeRequest request, CinemaContext context) => 
            {
                await context.AddAsync(new Filme(request.nome));
                await context.SaveChangesAsync();
                return Results.Ok(request);
            });
        route.MapGet("", 
            async (CinemaContext context) => 
            {
                var filme = await context.filmes.Where(f => f.Ativo == true).ToListAsync();
                if (filme == null)
                    return Results.NotFound();
                
                return Results.Ok(filme);
            });
        route.MapPut("{id:guid}", 
            async (Guid id, FilmeRequest req, CinemaContext context) => 
            { 
                var filme = await context.filmes.FirstOrDefaultAsync(f => f.Id == id);
                if (filme == null)
                    return Results.NotFound();
                filme.ChangeName(req.nome);
                await context.SaveChangesAsync();
                return Results.Ok(filme);
            });
        route.MapDelete("{id:guid}",
            async(Guid id, CinemaContext context) =>
            {
                var filme = await context.filmes.FirstOrDefaultAsync(f => f.Id == id);
                if (filme == null)
                    return Results.NotFound();
                filme.SetInactive();
                await context.SaveChangesAsync();
                return Results.Ok();
            });
    }
}
