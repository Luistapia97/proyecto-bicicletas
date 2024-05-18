using Catalogo.Modelos;

namespace Catalogo.Repositorio
{
    public interface IRepositorioAlquileres
    {
        Task<List<Alquiler>> GetAll();
        Task<Alquiler?> Get(int id);
        Task<Alquiler> Add(Alquiler alquiler);
        Task Update(int id, Alquiler alquiler);
        Task Delete(int id);
       
    }
}

