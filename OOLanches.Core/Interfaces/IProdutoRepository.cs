using OOLanches.Core.Entities;

namespace OOLanches.Core.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(int categoriaId);
        Task<IEnumerable<Produto>> ObterProdutosPopularesAsync();
        Task<IEnumerable<Produto>> ObterProdutosMaisVendidosAsync();
        Task<Produto> ObterDetalheProdutoAsync(int id);
    }
}
