using Catalogo.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repositorio
{
    public class RepositorioBicicletas : IRepositorioBicicletas
    {
        private readonly CatalogoDBContext _context;

        public RepositorioBicicletas(CatalogoDBContext context)
        {
            _context = context;
        }

        public async Task<Bicicleta> Add(Bicicleta bicicleta)
        {
            await _context.Bicicletas.AddAsync(bicicleta);
            await _context.SaveChangesAsync();
            return bicicleta;
        }

        public async Task Delete(int id)
        {
            var bicicletas = await _context.Bicicletas.FindAsync(id);
            if (bicicletas != null)
            {
                _context.Bicicletas.Remove(bicicletas);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Bicicleta?> Get(int id)
        {
            return await _context.Bicicletas.FindAsync(id);
        }

        public async Task<List<Bicicleta>> GetAll()
        {
            return await _context.Bicicletas.ToListAsync();
        }


        public async Task Update(int id, Bicicleta bicicleta)
        {
            var bicicletaactual = await _context.Bicicletas.FindAsync(id);
            if (bicicletaactual != null)
            {
                bicicletaactual.Color = bicicleta.Color;
                bicicletaactual.Tipo = bicicleta.Tipo;
                bicicletaactual.Estado = bicicleta.Estado;
                await _context.SaveChangesAsync();
            }
        }

    }
}
