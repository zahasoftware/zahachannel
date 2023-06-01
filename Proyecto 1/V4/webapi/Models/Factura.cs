using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Factura
{
    public int Id { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetallesFactura> DetallesFacturas { get; set; } = new List<DetallesFactura>();
}
