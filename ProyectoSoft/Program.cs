using System;
using System.Collections.Generic;

namespace CompaniaAutos
{
    class Program
    {
        static List<Auto> inventarioAutos = new List<Auto>();
        static List<Venta> ventasRealizadas = new List<Venta>();
        static List<Cliente> listaClientes = new List<Cliente>();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Bienvenido a la compañía de ventas de autos");
                Console.WriteLine("1. Ver inventario");
                Console.WriteLine("2. Agregar vehículo al inventario");
                Console.WriteLine("3. Realizar venta");
                Console.WriteLine("4. Ver ventas realizadas");
                Console.WriteLine("5. Registrar cliente");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerInventario();
                        break;
                    case "2":
                        AgregarVehiculo();
                        break;
                    case "3":
                        RealizarVenta();
                        break;
                    case "4":
                        VerVentasRealizadas();
                        break;
                    case "5":
                        RegistrarCliente();
                        break;
                    case "6":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void VerInventario()
        {
            Console.WriteLine("Inventario de autos:");

            if (inventarioAutos.Count == 0)
            {
                Console.WriteLine("No hay autos en el inventario.");
            }
            else
            {
                foreach (var auto in inventarioAutos)
                {
                    Console.WriteLine($"Marca: {auto.Marca}, Modelo: {auto.Modelo}, Placa: {auto.Placa}, Stock: {auto.Stock}, Precio: {auto.Precio}");
                }
            }
        }

        static void AgregarVehiculo()
        {
            Console.WriteLine("Ingrese los detalles del vehículo:");

            try
            {
                Console.Write("Marca: ");
                string marca = LeerTextoAlfanumerico();

                Console.Write("Modelo: ");
                string modelo = LeerTextoAlfanumerico();

                Console.Write("Placa: ");
                string placa = LeerTextoAlfanumerico();

                Console.Write("Stock: ");
                int stock = LeerNumeroEntero();

                Console.Write("Precio: ");
                decimal precio = LeerNumeroDecimal();

                Auto nuevoAuto = new Auto
                {
                    Marca = marca,
                    Modelo = modelo,
                    Placa = placa,
                    Stock = stock,
                    Precio = precio
                };

                inventarioAutos.Add(nuevoAuto);

                Console.WriteLine("El vehículo se ha agregado al inventario.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error de formato: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static string LeerTextoAlfanumerico()
        {
            string input = Console.ReadLine();
            if (!EsAlfanumerico(input))
            {
                throw new FormatException("Solo se permiten valores alfanuméricos.");
            }
            return input;
        }

        static bool EsAlfanumerico(string input)
        {
            return input.All(c => char.IsLetterOrDigit(c));
        }

        static int LeerNumeroEntero()
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int numero))
            {
                throw new FormatException("Debe ingresar un número entero válido.");
            }
            return numero;
        }

        static decimal LeerNumeroDecimal()
        {
            string input = Console.ReadLine();
            if (!decimal.TryParse(input, out decimal numero))
            {
                throw new FormatException("Debe ingresar un valor decimal válido.");
            }
            return numero;
        }


        static void RealizarVenta()
        {
            Console.WriteLine("Ingrese los detalles de la venta:");

            Console.Write("Marca del auto: ");
            string marca = Console.ReadLine();

            Console.Write("Placa del auto: ");
            string placa = Console.ReadLine();

            Console.Write("DNI del cliente: ");
            string dniCliente = Console.ReadLine();

            Auto autoSeleccionado = null;
            foreach (var auto in inventarioAutos)
            {
                if (auto.Marca == marca && auto.Placa == placa)
                {
                    autoSeleccionado = auto;
                    break;
                }
            }

            Cliente clienteSeleccionado = null;
            foreach (var cliente in listaClientes)
            {
                if (cliente.DNI == dniCliente)
                {
                    clienteSeleccionado = cliente;
                    break;
                }
            }

            if (autoSeleccionado != null && clienteSeleccionado != null)
            {
                Console.Write("Cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (autoSeleccionado.Stock >= cantidad)
                {
                    decimal montoTotal = autoSeleccionado.Precio * cantidad;
                    autoSeleccionado.Stock -= cantidad;

                    Venta nuevaVenta = new Venta
                    {
                        MarcaAuto = autoSeleccionado.Marca,
                        ModeloAuto = autoSeleccionado.Modelo,
                        Cantidad = cantidad,
                        MontoTotal = montoTotal,
                        FechaVenta = DateTime.Now
                    };

                    ventasRealizadas.Add(nuevaVenta);

                    Console.WriteLine("La venta se ha realizado exitosamente.");

                    Console.WriteLine($"Fecha: {nuevaVenta.FechaVenta}, Marca: {nuevaVenta.MarcaAuto}, Modelo: {nuevaVenta.ModeloAuto}, Cantidad: {nuevaVenta.Cantidad}, Monto total: {nuevaVenta.MontoTotal}");
                    

                }
                else
                {
                    Console.WriteLine("No hay suficiente stock disponible para realizar la venta.");
                }
            }
            else
            {
                Console.WriteLine("El auto o el cliente ingresado no se encuentra en el inventario o en la lista de clientes.");
            }
        }

        static void VerVentasRealizadas()
        {
            Console.WriteLine("Ventas realizadas:");

            if (ventasRealizadas.Count == 0)
            {
                Console.WriteLine("No se ha realizado ninguna venta.");
            }
            else
            {
                foreach (var venta in ventasRealizadas)
                {
                    Console.WriteLine($"Fecha: {venta.FechaVenta}, Marca: {venta.MarcaAuto}, Modelo: {venta.ModeloAuto}, Cantidad: {venta.Cantidad}, Monto total: {venta.MontoTotal}");
                }
            }
        }

        static void RegistrarCliente()
        {
            Console.WriteLine("Ingrese los detalles del cliente:");

            try
            {
                Console.Write("DNI: ");
                string dni = Console.ReadLine();

                if (!EsNumero(dni))
                {
                    throw new FormatException("El DNI debe contener solo números.");
                }

                Console.Write("Nombres: ");
                string nombres = Console.ReadLine();

                if (!EsLetra(nombres))
                {
                    throw new FormatException("Los nombres deben contener solo letras.");
                }

                Console.Write("Edad: ");
                int edad = int.Parse(Console.ReadLine());

                Console.Write("Forma de pago: ");
                string formaPago = Console.ReadLine();

                Cliente nuevoCliente = new Cliente
                {
                    DNI = dni,
                    Nombres = nombres,
                    Edad = edad,
                    FormaPago = formaPago
                };

                listaClientes.Add(nuevoCliente);

                Console.WriteLine("El cliente se ha registrado exitosamente.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error de formato: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static bool EsNumero(string input)
        {
            return int.TryParse(input, out _);
        }

        static bool EsLetra(string input)
        {
            return input.All(c => char.IsLetter(c));
        }

    }
}
