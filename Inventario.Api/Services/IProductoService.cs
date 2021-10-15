using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventario.Api.Domain;
using Inventario.Api.Services.Dtos;

namespace Inventario.Api.Services
{
    public interface IProductoService
    {
        Task SaveProductosAlmacen(IEnumerable<ProductoDto> productos, Guid idAlmacen);
        Task<IEnumerable<ProductoDto>> GetProductosByAlmacenId(Guid idAlmacen);
    }
}