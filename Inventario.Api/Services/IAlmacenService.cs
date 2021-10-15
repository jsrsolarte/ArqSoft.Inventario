using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventario.Api.Domain;
using Inventario.Api.Services.Dtos;

namespace Inventario.Api.Services
{
    public interface IAlmacenService
    {
        Task<AlmacenDto> GetAlmacenById(Guid id);
        Task CreateAlmacen(AlmacenDto almacenDto);
    }
}