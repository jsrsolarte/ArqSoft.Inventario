using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Inventario.Api.Domain;
using Inventario.Api.Services;
using Inventario.Api.Services.Dtos;

namespace Inventario.Api.Repository
{
    public class AlmacenService : IAlmacenService
    {
        private readonly IGenericRepository<Almacen> _repository;

        public AlmacenService(IGenericRepository<Almacen> repository)
        {
            _repository = repository;
        }


        public Task<AlmacenDto> GetAlmacenById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAlmacen(AlmacenDto almacenDto)
        {
            var almacen = JsonSerializer.Deserialize<Almacen>(JsonSerializer.Serialize(almacenDto));
            await _repository.Add(almacen);
        }
    }
}