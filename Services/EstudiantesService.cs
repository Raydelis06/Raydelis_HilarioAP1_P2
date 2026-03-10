using Microsoft.EntityFrameworkCore;
using Raydelis_HilarioAP1_P2.DAL;
using Raydelis_HilarioAP1_P2.Models;
using System.Linq.Expressions;

namespace Raydelis_HilarioAP1_P2.Services
{
    public class EstudiantesService(IDbContextFactory<Contexto> DbFactory)
    {
        //Metodo listar
        public async Task<List<Estudiantes>> Listar(Expression<Func<Estudiantes, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.Where(criterio).ToListAsync();
        }
        //metodo buscar
        public async Task<Estudiantes?> Buscar(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.FirstOrDefaultAsync(p => p.EstudianteId == estudianteId);
        }
        //metodo modificar
        public async Task<bool> Modificar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Estudiantes.Update(estudiante);
            return await contexto.SaveChangesAsync() > 0;
        }
    }
}
