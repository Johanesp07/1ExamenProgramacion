using System;
using System.Collections.Generic;

namespace TallerMecanico
{
    class Program
    {
        static void Main()
        {
            List<Cliente> clientes = new List<Cliente>();
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Servicio> servicios = new List<Servicio>();
            List<Mecanico> mecanicos = new List<Mecanico>();
            List<Cita> citas = new List<Cita>();

            // Datos de ejemplo
            Cliente cliente1 = new Cliente("Juan Perez", "Calle Falsa 123", "555-1234", "juan.perez@example.com");
            clientes.Add(cliente1);
            Vehiculo vehiculo1 = new Vehiculo("Toyota", "Corolla", 2020, "ABC123456", cliente1);
            vehiculos.Add(vehiculo1);
            Servicio servicio1 = new Servicio("Cambio de Aceite", "Cambio de aceite del motor", 50);
            servicios.Add(servicio1);
            Mecanico mecanico1 = new Mecanico("Pedro Gómez", "Motor", true);
            mecanicos.Add(mecanico1);

            while (true)
            {
                Console.WriteLine("Sistema de Gestión de Taller Mecánico");
                Console.WriteLine("1. Gestión de Clientes");
                Console.WriteLine("2. Registrar Vehículo");
                Console.WriteLine("3. Registrar Servicio");
                Console.WriteLine("4. Agendar Cita");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        GestionDeClientes(clientes);
                        break;

                    case 2:
                        // Registrar Vehículo
                        Console.Write("Marca: ");
                        string marca = Console.ReadLine();
                        Console.Write("Modelo: ");
                        string modelo = Console.ReadLine();
                        Console.Write("Año: ");
                        int año = int.Parse(Console.ReadLine());
                        Console.Write("VIN: ");
                        string vin = Console.ReadLine();
                        Console.Write("Nombre del Propietario: ");
                        string nombrePropietario = Console.ReadLine();
                        Cliente propietario = clientes.Find(c => c.Nombre == nombrePropietario);
                        if (propietario != null)
                        {
                            Vehiculo nuevoVehiculo = new Vehiculo(marca, modelo, año, vin, propietario);
                            vehiculos.Add(nuevoVehiculo);
                            Console.WriteLine("Vehículo registrado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Propietario no encontrado.");
                        }
                        break;

                    case 3:
                        // Registrar Servicio
                        Console.Write("Nombre del Servicio: ");
                        string nombreServicio = Console.ReadLine();
                        Console.Write("Descripción: ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Costo: ");
                        double costo = double.Parse(Console.ReadLine());
                        Servicio nuevoServicio = new Servicio(nombreServicio, descripcion, costo);
                        servicios.Add(nuevoServicio);
                        Console.WriteLine("Servicio registrado con éxito.");
                        break;

                    case 4:
                        // Agendar Cita
                        Console.Write("Nombre del Cliente: ");
                        string nombreCliente = Console.ReadLine();
                        cliente1 = clientes.Find(c => c.Nombre == nombreCliente);
                        if (cliente1 == null)
                        {
                            Console.WriteLine("Cliente no encontrado.");
                            break;
                        }

                        Console.Write("VIN del Vehículo: ");
                        vin = Console.ReadLine();
                        vehiculo1 = vehiculos.Find(v => v.VIN == vin);
                        if (vehiculo1 == null)
                        {
                            Console.WriteLine("Vehículo no encontrado.");
                            break;
                        }

                        Console.Write("Nombre del Servicio: ");
                        nombreServicio = Console.ReadLine();
                        servicio1 = servicios.Find(s => s.Nombre == nombreServicio);
                        if (servicio1 == null)
                        {
                            Console.WriteLine("Servicio no encontrado.");
                            break;
                        }

                        Console.Write("Nombre del Mecánico: ");
                        string nombreMecanico = Console.ReadLine();
                        mecanico1 = mecanicos.Find(m => m.Nombre == nombreMecanico && m.Disponible);
                        if (mecanico1 == null)
                        {
                            Console.WriteLine("Mecánico no disponible.");
                            break;
                        }

                        Console.Write("Fecha y Hora (dd/MM/yyyy HH:mm): ");
                        DateTime fechaHora = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);

                        Cita nuevaCita = new Cita(fechaHora, cliente1, vehiculo1, servicio1, mecanico1);
                        citas.Add(nuevaCita);
                        mecanico1.Disponible = false;
                        Console.WriteLine("Cita agendada con éxito.");
                        break;

                    case 5:
                        // Salir
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void GestionDeClientes(List<Cliente> clientes)
        {
            while (true)
            {
                Console.WriteLine("Gestión de Clientes");
                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Editar Cliente");
                Console.WriteLine("3. Listar Clientes");
                Console.WriteLine("4. Eliminar Cliente");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        // Registrar Cliente
                        Console.Write("Nombre: ");
                        string nombreCliente = Console.ReadLine();
                        Console.Write("Dirección: ");
                        string direccion = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        string telefono = Console.ReadLine();
                        Console.Write("Correo Electrónico: ");
                        string correo = Console.ReadLine();
                        Cliente nuevoCliente = new Cliente(nombreCliente, direccion, telefono, correo);
                        clientes.Add(nuevoCliente);
                        Console.WriteLine("Cliente registrado con éxito.");
                        break;

                    case 2:
                        // Editar Cliente
                        Console.Write("Nombre del Cliente a Editar: ");
                        nombreCliente = Console.ReadLine();
                        Cliente clienteEditar = clientes.Find(c => c.Nombre == nombreCliente);
                        if (clienteEditar != null)
                        {
                            Console.Write("Nuevo Nombre (dejar vacío para no cambiar): ");
                            string nuevoNombre = Console.ReadLine();
                            Console.Write("Nueva Dirección (dejar vacío para no cambiar): ");
                            string nuevaDireccion = Console.ReadLine();
                            Console.Write("Nuevo Teléfono (dejar vacío para no cambiar): ");
                            string nuevoTelefono = Console.ReadLine();
                            Console.Write("Nuevo Correo Electrónico (dejar vacío para no cambiar): ");
                            string nuevoCorreo = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(nuevoNombre)) clienteEditar.Nombre = nuevoNombre;
                            if (!string.IsNullOrWhiteSpace(nuevaDireccion)) clienteEditar.Direccion = nuevaDireccion;
                            if (!string.IsNullOrWhiteSpace(nuevoTelefono)) clienteEditar.Telefono = nuevoTelefono;
                            if (!string.IsNullOrWhiteSpace(nuevoCorreo)) clienteEditar.CorreoElectronico = nuevoCorreo;

                            Console.WriteLine("Cliente editado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Cliente no encontrado.");
                        }
                        break;

                    case 3:
                        // Listar Clientes
                        Console.WriteLine("Lista de Clientes:");
                        foreach (Cliente cliente in clientes)
                        {
                            Console.WriteLine(cliente);
                        }
                        break;

                    case 4:
                        // Eliminar Cliente
                        Console.Write("Nombre del Cliente a Eliminar: ");
                        nombreCliente = Console.ReadLine();
                        Cliente clienteEliminar = clientes.Find(c => c.Nombre == nombreCliente);
                        if (clienteEliminar != null)
                        {
                            clientes.Remove(clienteEliminar);
                            Console.WriteLine("Cliente eliminado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Cliente no encontrado.");
                        }
                        break;

                    case 5:
                        // Volver al menú principal
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }

    public class Cliente
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public Cliente(string nombre, string direccion, string telefono, string correoElectronico)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Dirección: {Direccion}, Teléfono: {Telefono}, Correo: {CorreoElectronico}";
        }
    }

    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string VIN { get; set; }
        public Cliente Propietario { get; set; }

        public Vehiculo(string marca, string modelo, int año, string vin, Cliente propietario)
        {
            Marca = marca;
            Modelo = modelo;
            Año = año;
            VIN = vin;
            Propietario = propietario;
        }

        public override string ToString()
        {
            return $"Marca: {Marca}, Modelo: {Modelo}, Año: {Año}, VIN: {VIN}, Propietario: {Propietario.Nombre}";
        }
    }

    public class Servicio
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }

        public Servicio(string nombre, string descripcion, double costo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Costo = costo;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Descripción: {Descripcion}, Costo: {Costo}";
        }
    }

    public class Mecanico
    {
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public bool Disponible { get; set; }

        public Mecanico(string nombre, string especialidad, bool disponible)
        {
            Nombre = nombre;
            Especialidad = especialidad;
            Disponible = disponible;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Especialidad: {Especialidad}, Disponible: {Disponible}";
        }
    }

    public class Cita
    {
        public DateTime FechaHora { get; set; }
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Servicio Servicio { get; set; }
        public Mecanico Mecanico { get; set; }

        public Cita(DateTime fechaHora, Cliente cliente, Vehiculo vehiculo, Servicio servicio, Mecanico mecanico)
        {
            FechaHora = fechaHora;
            Cliente = cliente;
            Vehiculo = vehiculo;
            Servicio = servicio;
            Mecanico = mecanico;
        }

        public override string ToString()
        {
            return $"Fecha y Hora: {FechaHora}, Cliente: {Cliente.Nombre}, Vehículo: {Vehiculo.Marca} {Vehiculo.Modelo}, Servicio: {Servicio.Nombre}, Mecánico: {Mecanico.Nombre}";
        }
    }
}
