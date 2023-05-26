using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class DetallesFactura
{
    public int Id { get; set; }

    public int? FacturaId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public virtual Factura? Factura { get; set; }

    public virtual Producto? Producto { get; set; }
}
