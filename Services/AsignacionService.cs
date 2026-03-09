using Microsoft.EntityFrameworkCore;
using Raydelis_HilarioAP1_P2.DAL;
using Raydelis_HilarioAP1_P2.Models;
using System.Linq.Expressions;

namespace Raydelis_HilarioAP1_P2.Services
{
    public class AsignacionService(IDbContextFactory<Contexto> DbFactory)
    {
        //Metodo listar
        public async Task<List<AsignacionesPuntos>> Listar(Expression<Func<AsignacionesPuntos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.AsignacionesPuntos.Where(criterio).Include(p => p.DetallesAsignacion).ToListAsync();
        }

        //Metodo guardar
        public async Task<bool> Guardar(AsignacionesPuntos asignacion)
        {
            if (!await Existe(asignacion.IdAsignacion))
            {
                return await Insertar(asignacion);
            }
            else
            {
                return await Modificar(asignacion);
            }
        }

        //Metodo insertar
        public async Task<bool> Insertar(AsignacionesPuntos asignacion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.AsignacionesPuntos.Add(asignacion);
            return await contexto.SaveChangesAsync() > 0;
        }

        //Metodo existe
        public async Task<bool> Existe(int asignacionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.AsignacionesPuntos.AnyAsync(p => p.IdAsignacion == asignacionId);
        }

        //metodo modificar
        public async Task<bool> Modificar(AsignacionesPuntos asignacion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.AsignacionesPuntos.Update(asignacion);
            return await contexto.SaveChangesAsync() > 0;
        }

        //metodo buscar
        public async Task<AsignacionesPuntos?> Buscar(int asignacionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.AsignacionesPuntos.Include(d => d.DetallesAsignacion).FirstOrDefaultAsync(p => p.IdAsignacion == asignacionId);
        }

        //eliminar
        public async Task<bool> Eliminar(int asignacionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var asignacion = await Buscar(asignacionId);

            if (asignacion == null) return false;

            contexto.RemoveRange(asignacion.DetallesAsignacion);
            contexto.AsignacionesPuntos.Remove(asignacion);
            return await contexto.SaveChangesAsync() > 0;
        }
    }
}
