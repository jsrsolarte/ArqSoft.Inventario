using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Inventario.Api.Domain;
using Inventario.Api.Services;
using Inventario.Api.Services.Dtos;

namespace Inventario.Api.Repository
{
    public class ProductoService : IProductoService
    {
        private IGenericRepository<Producto> _productoRepository;
        private readonly IGenericRepository<Almacen> _almacenRepository;

        public ProductoService(IGenericRepository<Almacen> almacenRepository,
            IGenericRepository<Producto> productoRepository)
        {
            _almacenRepository = almacenRepository;
            _productoRepository = productoRepository;
        }

        public async Task SaveProductosAlmacen(IEnumerable<ProductoDto> productosDto, Guid idAlmacen)
        {
            var almacen = await _almacenRepository.GetById(idAlmacen);
            foreach (var productoDto in productosDto)
            {
                var producto = JsonSerializer.Deserialize<Producto>(JsonSerializer.Serialize(productoDto));
                if (producto != null)
                {
                    producto.Almacen = almacen;
                    await _productoRepository.Add(producto);
                }
            }
        }

        public async Task<IEnumerable<ProductoDto>> GetProductosByAlmacenId(Guid idAlmacen)
        {
            var productos = (await _productoRepository.Get(x => x.Almacen)).Where(x => x.Almacen.Id.Equals(idAlmacen));

            var prods = JsonSerializer.Serialize(productos);
            var productosDto = JsonSerializer.Deserialize<IEnumerable<ProductoDto>>(prods);

            return productosDto;
        }
    }
}