namespace UnitTests;

public class Tests
{
    [Test]
    public void BookingMustToBeValidateDate()
    {
        //Assert
        DateTime date = new DateTime(2025, 4, 29, 13, 10, 20);
        Clinica clinica = new Clinica("Clínica Veterinaria", "Avenida Central 456", "987654321");
        Dueno dueno = new Dueno("Juan", "Pérez", "123456789", "Calle Principal 123");
        Mascota mascota = new Mascota("Firulais", "Perro", "Labrador", 5, dueno, clinica);
        Cita cita = new Cita(mascota, date, "Vacuna anual");
        //Act
        cita.Reservar(DateTime.Now);
        //Assert
        Assert.AreEqual("Reservada", cita.Estado);
    }

    [Test]
    public void CancelReservationMustToBeVaidateDate()
    {
        //Assert
        DateTime date = new DateTime(2025, 4, 29, 14, 10, 20);
        Clinica clinica = new Clinica("Clínica Veterinaria", "Avenida Central 456", "987654321");
        Dueno dueno = new Dueno("Juan", "Pérez", "123456789", "Calle Principal 123");
        Mascota mascota = new Mascota("Firulais", "Perro", "Labrador", 5, dueno, clinica);
        Cita cita = new Cita(mascota, date, "Vacuna anual");
        //Act
        cita.Cancelar(DateTime.Now);
        //Assert
        Assert.AreEqual("Cancelada", cita.Estado);
    }

    [Test]
    public void CloseReservationMustToBeWorking()
    {
        //Assert
        DateTime date = new DateTime(2025, 4, 29, 14, 10, 20);
        Clinica clinica = new Clinica("Clínica Veterinaria", "Avenida Central 456", "987654321");
        Dueno dueno = new Dueno("Juan", "Pérez", "123456789", "Calle Principal 123");
        Mascota mascota = new Mascota("Firulais", "Perro", "Labrador", 5, dueno, clinica);
        Cita cita = new Cita(mascota, date, "Vacuna anual");
        //Act
        cita.Cerrar(DateTime.Now);
        //Assert
        Assert.AreEqual("Cerrada", cita.Estado);
    }

    [Test]
    public void OpenReservationMustToBeWorking()
    {
        //Assert
        DateTime date = new DateTime(2025, 4, 29, 14, 10, 20);
        Clinica clinica = new Clinica("Clínica Veterinaria", "Avenida Central 456", "987654321");
        Dueno dueno = new Dueno("Juan", "Pérez", "123456789", "Calle Principal 123");
        Mascota mascota = new Mascota("Firulais", "Perro", "Labrador", 5, dueno, clinica);
        Cita cita = new Cita(mascota, date, "Vacuna anual");
        //Act
        cita.Reservar(DateTime.Now);
        cita.Cancelar(DateTime.Now);
        cita.Cerrar(DateTime.Now);
        //Assert
        Assert.AreEqual("Cerrada", cita.Estado);
    }
}