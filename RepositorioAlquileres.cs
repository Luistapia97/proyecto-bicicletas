using Catalogo.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repositorio
{
    public class RepositorioAlquileres : IRepositorioAlquileres
    {
        private readonly CatalogoDBContext _context;

        public RepositorioAlquileres(CatalogoDBContext context)
        {
            _context = context;
        }

        public async Task<Alquiler> Add(Alquiler alquiler)
        {
            await _context.Alquileres.AddAsync(alquiler);
            await _context.SaveChangesAsync();
            return alquiler;
        }

        public async Task Delete(int id)
        {
            var alquileres = await _context.Alquileres.FindAsync(id);
            if (alquileres != null)
            {
                _context.Alquileres.Remove(alquileres);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Alquiler?> Get(int id)
        {
            return await _context.Alquileres.FindAsync(id);
        }

        public async Task<List<Alquiler>> GetAll()
        {
            return await _context.Alquileres.ToListAsync();
        }
   
        public async Task Update(int id, Alquiler alquiler)
        {
            var alquileractual = await _context.Alquileres.FindAsync(id);
            if (alquileractual != null)
            {
                alquileractual.FechaInicio = alquiler.FechaInicio;
                alquileractual.FechaFin = alquiler.FechaFin;
                await _context.SaveChangesAsync();
            }
        }

    }
}
