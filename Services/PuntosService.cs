using Microsoft.EntityFrameworkCore;
using Raydelis_HilarioAP1_P2.DAL;
using Raydelis_HilarioAP1_P2.Models;
using System.Linq.Expressions;

namespace Raydelis_HilarioAP1_P2.Services;

public class PuntosService(IDbContextFactory<Contexto> DbFactory)
{
    //Metodo listar
    public async Task<List<TiposPuntos>> Listar(Expression<Func<TiposPuntos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos.Where(criterio).ToListAsync();
    }
    //metodo buscar
    public async Task<TiposPuntos?> Buscar(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos.FirstOrDefaultAsync(p => p.TipoId == tipoId);
    }
}
