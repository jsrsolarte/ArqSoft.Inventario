using System;

namespace Inventario.Api.Domain
{
    public class Almacen
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
    }
}