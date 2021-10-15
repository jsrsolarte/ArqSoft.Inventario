using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventario.Api.Services;
using Inventario.Api.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("{idAlmacen:guid}")]
        public async Task<IEnumerable<ProductoDto>> GetProductosByAlmacen(Guid idAlmacen)
        {
            return await _productoService.GetProductosByAlmacenId(idAlmacen);
        }

        [HttpPost("{idAlmacen:guid}")]
        public async Task<ActionResult> CreateProductosByAlmacen(IEnumerable<ProductoDto> productos, Guid idAlmacen)
        {
            await _productoService.SaveProductosAlmacen(productos, idAlmacen);
            return Ok();
        }
    }
}