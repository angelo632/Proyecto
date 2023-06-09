using System;

public class Program
{
    public static void Main(string[] args)
    {
        Agencia agencia = new Agencia();

        agencia.AgregarVehiculo("ABC123", 25000, "Toyota Corolla", 2022, "Rojo");
        agencia.AgregarVehiculo("DEF456", 22000, "Honda Civic", 2021, "Azul");
        agencia.AgregarVehiculo("GHI789", 45000, "Ford Mustang", 2023, "Negro");

        agencia.MostrarVehiculos();

        agencia.ActualizarVehiculo("ABC123", 27000, "Toyota Corolla XLE", 2022, "Rojo");
        agencia.EliminarVehiculo("DEF456");

        agencia.MostrarVehiculos();

        Console.ReadLine();
    }
}
