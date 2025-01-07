using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OOLanches.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        // Este endpoint pode ser usado para verificar se a API esta em atendimento
        // Ele não esta sendo usado pela aplicação e foi criado para mostrar um exemplo
        // de como implementar esta funcionalidade
        // GET: api/status
        [HttpGet]
        public IActionResult GetStatus()
        {
            // Retorna um status HTTP 200 OK indicando que a API está disponível
            return Ok(new { status = "API disponível" });
        }
    }
}
