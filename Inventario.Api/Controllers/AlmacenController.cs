using System.Threading.Tasks;
using Inventario.Api.Services;
using Inventario.Api.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class AlmacenController : ControllerBase
    {
        private readonly IAlmacenService _almacenService;

        public AlmacenController(IAlmacenService almacenService)
        {
            _almacenService = almacenService;
        }

        [HttpPost]
        public async Task CreateAlmacen(string nombre)
        {
            var almacen = new AlmacenDto
            {
                Nombre = nombre
            };
            await _almacenService.CreateAlmacen(almacen);
        }
    }
}