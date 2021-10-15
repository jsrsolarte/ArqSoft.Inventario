using System;

namespace Inventario.Api.Domain
{
    public class Producto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public Almacen Almacen { get; set; }
    }
}