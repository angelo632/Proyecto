using System;

class Program
{
    static void Main()
    {
        AgenciaDeVentas agencia = new AgenciaDeVentas();

        // Agregar algunos vehículos de ejemplo
        agencia.AgregarVehiculo(new Vehiculo("ABC123", 15000, "Sedán", 2018, "Rojo"));
        agencia.AgregarVehiculo(new Vehiculo("XYZ789", 25000, "SUV", 2020, "Negro"));

        // Realizar una venta con financiamiento
        agencia.RealizarVentaFinanciamiento("ABC123", 10000, 12); // Placa del vehículo, monto financiado, número de cuotas

        // Mostrar información de las ventas realizadas
        agencia.MostrarVentas();
    }
}

class Vehiculo
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

class Venta
{
    public Vehiculo Vehiculo { get; set; }
    public decimal MontoTotal { get; set; }
    public int NumeroCuotas { get; set; }

    public Venta(Vehiculo vehiculo, decimal montoTotal, int numeroCuotas)
    {
        Vehiculo = vehiculo;
        MontoTotal = montoTotal;
        NumeroCuotas = numeroCuotas;
    }
}

class AgenciaDeVentas
{
    private List<Vehiculo> vehiculos;
    private List<Venta> ventas;

    public AgenciaDeVentas()
    {
        vehiculos = new List<Vehiculo>();
        ventas = new List<Venta>();
    }

    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        vehiculos.Add(vehiculo);
    }

    public void RealizarVentaFinanciamiento(string placa, decimal montoFinanciado, int numeroCuotas)
    {
        Vehiculo vehiculo = vehiculos.Find(v => v.Placa == placa);

        if (vehiculo != null)
        {
            decimal montoTotal = vehiculo.Precio - montoFinanciado;
            Venta venta = new Venta(vehiculo, montoTotal, numeroCuotas);
            ventas.Add(venta);
            Console.WriteLine("Venta realizada con financiamiento:");
            Console.WriteLine($"Vehículo: {vehiculo.Modelo} - Placa: {vehiculo.Placa}");
            Console.WriteLine($"Monto Total: {montoTotal:C} - Número de Cuotas: {numeroCuotas}");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No se encontró el vehículo con la placa especificada.");
        }
    }

    public void MostrarVentas()
    {
        Console.WriteLine("Ventas realizadas:");
        foreach (Venta venta in ventas)
        {
            Console.WriteLine($"Vehículo: {venta.Vehiculo.Modelo} - Placa: {venta.Vehiculo.Placa}");
            Console.WriteLine($"Monto Total: {venta.MontoTotal:C} - Número de Cuotas: {venta.NumeroCuotas}");
            Console.WriteLine();
        }
    }
}
