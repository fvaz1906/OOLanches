using Microsoft.EntityFrameworkCore;
using OOLanches.Core.Context;
using OOLanches.Core.Entities;
using OOLanches.Core.Interfaces;

namespace OOLanches.Core.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext dbContext;

        public CategoriaRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await dbContext.Categorias.AsNoTracking().ToListAsync();
        }
    }
}
