using Bogus;
using webapi.Models;

public static class Seed{
public static void GenerarDatosFalsos()
{
    using (var context = new MiProyectoContext())
    {
        var faker = new Faker();

                // Eliminar datos existentes de las tablas
        context.Clientes.RemoveRange(context.Clientes);
        context.Productos.RemoveRange(context.Productos);
        context.DetallesFacturas.RemoveRange(context.DetallesFacturas);
        context.Facturas.RemoveRange(context.Facturas);
        context.SaveChanges();

        // Generar datos falsos para la tabla "clientes"
        var clientes = new List<Cliente>();
        for (int i = 0; i < 10; i++)
        {
            var cliente = new Cliente
            {
                Id = i+1,
                Nombre = faker.Name.FullName(),
                Direccion = faker.Address.FullAddress(),
                Telefono = faker.Phone.PhoneNumber()
            };
            clientes.Add(cliente);
        }
        context.Clientes.AddRange(clientes);

        // Generar datos falsos para la tabla "productos"
        var productos = new List<Producto>();
        for (int i = 0; i < 10; i++)
        {
            var producto = new Producto
            {
                Id = i+1,
                Nombre = faker.Commerce.ProductName(),
                Precio = decimal.Parse(faker.Commerce.Price()),
                Descripcion = faker.Lorem.Sentence()
            };
            productos.Add(producto);
        }
        context.Productos.AddRange(productos);

        // Generar datos falsos para la tabla "facturas" y "detalles_facturas"
        var facturas = new List<Factura>();
        var detallesFacturas = new List<DetallesFactura>();
        for (int i = 0; i < 10; i++)
        {
            var factura = new Factura
            {
                Id = i+1,
                Fecha = DateOnly.FromDateTime(faker.Date.Past()),
                ClienteId = clientes[faker.Random.Number(0, clientes.Count - 1)].Id
            };
            facturas.Add(factura);

            var detalleFactura = new DetallesFactura
            {
                FacturaId = factura.Id,
                ProductoId = productos[faker.Random.Number(0, productos.Count - 1)].Id,
                Cantidad = faker.Random.Number(1, 10),
                Precio = decimal.Parse(faker.Commerce.Price())
            };
            detallesFacturas.Add(detalleFactura);
        }
        context.Facturas.AddRange(facturas);
        context.DetallesFacturas.AddRange(detallesFacturas);

        context.SaveChanges();
    }
}

}