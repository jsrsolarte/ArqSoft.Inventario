using System;

namespace Inventario.Api.Services.Dtos
{
    public class ProductoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }
}