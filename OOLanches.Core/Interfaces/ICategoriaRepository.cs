using OOLanches.Core.Entities;

namespace OOLanches.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategorias();
    }
}
