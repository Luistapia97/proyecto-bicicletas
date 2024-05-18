using Catalogo.Modelos;

namespace Catalogo.Repositorio
{
    public interface IRepositorioBicicletas
    {
        Task<List<Bicicleta>> GetAll();
        Task<Bicicleta?> Get(int id);
        Task<Bicicleta> Add(Bicicleta bicicleta);
        Task Update(int id, Bicicleta bicicleta);
        Task Delete(int id);
    }
}
