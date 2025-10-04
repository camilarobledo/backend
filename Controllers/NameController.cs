using Microsoft.AspNetCore.Mvc;

namespace MiPrimerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {

        /// <summary>Devuelve un valor de prueba</summary>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
