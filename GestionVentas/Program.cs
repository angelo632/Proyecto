using System;
using System.Collections.Generic;

public class Vehiculo
{
    public string Placa { get; set; }
    public decimal Precio { get; set; }
    public string Modelo { get; set; }
    public int Anio { get; set; }
    public string Color { get; set; }

    public Vehiculo(string placa, decimal precio, string modelo, int anio, string color)
    {
        Placa = placa;
        Precio = precio;
        Modelo = modelo;
        Anio = anio;
        Color = color;
    }
}

public class Venta
{
    public Vehiculo Vehiculo { get; set; }
    public DateTime FechaVenta { get; set; }
    public decimal MontoTotal { get; set; }

    public Venta(Vehiculo vehiculo, DateTime fechaVenta, decimal montoTotal)
    {
        Vehiculo = vehiculo;
        FechaVenta = fechaVenta;
        MontoTotal = montoTotal;
    }
}

public class Agencia
{
    private List<Vehiculo> vehiculos;
    private List<Venta> ventas;

    public Agencia()
    {
        vehiculos = new List<Vehiculo>();
        ventas = new List<Venta>();
    }

    public void AgregarVehiculo(string placa, decimal precio, string modelo, int anio, string color)
    {
        Vehiculo vehiculo = new Vehiculo(placa, precio, modelo, anio, color);
        vehiculos.Add(vehiculo);
        Console.WriteLine("Vehículo agregado correctamente.");
    }

    public void RealizarVenta(string placa, decimal montoTotal)
    {
        Vehiculo vehiculoEncontrado = vehiculos.Find(v => v.Placa == placa);
        if (vehiculoEncontrado != null)
        {
            Venta venta = new Venta(vehiculoEncontrado, DateTime.Now, montoTotal);
            ventas.Add(venta);
            Console.WriteLine("Venta registrada correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró ningún vehículo con esa placa.");
        }
    }

    public void MostrarVentas()
    {
        if (ventas.Count == 0)
        {
            Console.WriteLine("No hay ventas registradas.");
        }
        else
        {
            Console.WriteLine("Ventas realizadas:");
            foreach (var venta in ventas)
            {
                Console.WriteLine($"Fecha: {venta.FechaVenta}, Placa: {venta.Vehiculo.Placa}, Precio: {venta.Vehiculo.Precio:C}, Modelo: {venta.Vehiculo.Modelo}, Monto Total: {venta.MontoTotal:C}");
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Agencia agencia = new Agencia();

        agencia.AgregarVehiculo("ABC123", 25000, "Toyota Corolla", 2022, "Rojo");
        agencia.AgregarVehiculo("DEF456", 22000, "Honda Civic", 2021, "Azul");
        agencia.AgregarVehiculo("GHI789", 45000, "Ford Mustang", 2023, "Negro");

        agencia.RealizarVenta("ABC123", 27000);
        agencia.RealizarVenta("GHI789", 40000);

        agencia.MostrarVentas();

        Console.ReadLine();
    }
}
