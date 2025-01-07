using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OOLanches.Core.Interfaces;

namespace OOLanches.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categorias = await categoriaRepository.GetCategorias();

            if (categorias is null)
                return NotFound();

            return Ok(categorias);
        }
    }
}
