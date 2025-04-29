using System;
using System.Collections.Generic;

public class Dueno
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }

    public Dueno(string nombre, string apellido, string telefono, string direccion)
    {
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Direccion = direccion;
    }
}

public class Mascota
{
    public string Nombre { get; set; }
    public string Especie { get; set; }
    public string Raza { get; set; }
    public int Edad { get; set; }
    public Dueno Dueno { get; set; }
    public Clinica Clinica { get; set; }

    public Mascota(string nombre, string especie, string raza, int edad, Dueno dueno, Clinica clinica)
    {
        Nombre = nombre;
        Especie = especie;
        Raza = raza;
        Edad = edad;
        Dueno = dueno;
        Clinica = clinica;
    }
}

public class Clinica
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Mascota> Mascotas { get; set; }

    public Clinica(string nombre, string direccion, string telefono)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Mascotas = new List<Mascota>();
    }
}

public class Cita
{
    public Mascota Mascota { get; set; }
    public DateTime Fecha { get; set; }
    public string Motivo { get; set; }
    public string Estado { get; set; } // "Reservada", "Cancelada", "Cerrada"
    public DateTime FechaReserva { get; set; }
    public DateTime FechaCancelacion { get; set; }
    public DateTime FechaCierre { get; set; }

    public Cita(Mascota mascota, DateTime fecha, string motivo)
    {
        Mascota = mascota;
        Fecha = fecha;
        Motivo = motivo;
        Estado = "Reservada";
        FechaReserva = DateTime.Now;

        Console.WriteLine($"Cita reservada para {mascota.Nombre} el {fecha} por motivo: {motivo}. Fecha de reserva: {FechaReserva}");
    }

    public void Reservar(DateTime fechaReserva)
    {
        if ((Fecha - fechaReserva).TotalMinutes >= 30)
        {
            Estado = "Reservada";
            FechaReserva = fechaReserva;
            Console.WriteLine($"La cita ha sido reservada para {Mascota.Nombre} en {fechaReserva}.");
        }
        else
        {
            Console.WriteLine("No se puede reservar la cita. Debe hacerse al menos 30 minutos antes de la fecha programada.");
        }
    }

    public void Cancelar(DateTime fechaCancelacion)
    {
        if ((Fecha - fechaCancelacion).TotalHours >= 3)
        {
            Estado = "Cancelada";
            FechaCancelacion = fechaCancelacion;
            Console.WriteLine($"La cita ha sido cancelada para {Mascota.Nombre} en {fechaCancelacion}.");
        }
        else
        {
            Console.WriteLine("No se puede cancelar la cita. Debe hacerse al menos 3 horas antes de la fecha programada.");
        }
    }

    public void Cerrar(DateTime fechaCierre)
    {
        Estado = "Cerrada";
        FechaCierre = fechaCierre;
        Console.WriteLine($"La cita ha sido cerrada para {Mascota.Nombre} en {fechaCierre}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dueno dueno = new Dueno("Juan", "Pérez", "123456789", "Calle Principal 123");
        Mascota mascota = new Mascota("Firulais", "Perro", "Labrador", 5, dueno, null);
        Clinica clinica = new Clinica("Clínica Veterinaria", "Avenida Central 456", "987654321");
        Cita cita = new Cita(mascota, new DateTime(2025, 4, 29, 13, 10, 20), "Vacuna anual");

        // Intentar reservar la cita
        cita.Reservar(DateTime.Now);

        // Intentar cancelar la cita
        cita.Cancelar(DateTime.Now);

        // Cerrar la cita ejecutada
        cita.Cerrar(DateTime.Now);
    }
} 