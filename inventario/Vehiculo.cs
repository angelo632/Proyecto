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

public class Agencia
{
    private List<Vehiculo> vehiculos;

    public Agencia()
    {
        vehiculos = new List<Vehiculo>();
    }

    public void AgregarVehiculo(string placa, decimal precio, string modelo, int anio, string color)
    {
        Vehiculo vehiculo = new Vehiculo(placa, precio, modelo, anio, color);
        vehiculos.Add(vehiculo);
        Console.WriteLine("Vehículo agregado correctamente.");
    }

    public void EliminarVehiculo(string placa)
    {
        Vehiculo vehiculoEncontrado = vehiculos.Find(v => v.Placa == placa);
        if (vehiculoEncontrado != null)
        {
            vehiculos.Remove(vehiculoEncontrado);
            Console.WriteLine("Vehículo eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró ningún vehículo con esa placa.");
        }
    }

    public void ActualizarVehiculo(string placa, decimal nuevoPrecio, string nuevoModelo, int nuevoAnio, string nuevoColor)
    {
        Vehiculo vehiculoEncontrado = vehiculos.Find(v => v.Placa == placa);
        if (vehiculoEncontrado != null)
        {
            vehiculoEncontrado.Precio = nuevoPrecio;
            vehiculoEncontrado.Modelo = nuevoModelo;
            vehiculoEncontrado.Anio = nuevoAnio;
            vehiculoEncontrado.Color = nuevoColor;
            Console.WriteLine("Vehículo actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró ningún vehículo con esa placa.");
        }
    }

    public void MostrarVehiculos()
    {
        if (vehiculos.Count == 0)
        {
            Console.WriteLine("No hay vehículos registrados.");
        }
        else
        {
            Console.WriteLine("Vehículos registrados:");
            foreach (var vehiculo in vehiculos)
            {
                Console.WriteLine($"Placa: {vehiculo.Placa}, Precio: {vehiculo.Precio:C}, Modelo: {vehiculo.Modelo}, Año: {vehiculo.Anio}, Color: {vehiculo.Color}");
            }
        }
    }
}


