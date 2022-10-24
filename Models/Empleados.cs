using System.ComponentModel.DataAnnotations;
using web_api_empleado.Models;

public class Empleados{
    [Key]

    public int idEmpleado{get;set;}
    public string Nombres{get;set;}
    public string Apellidos{get;set;}
    public string Direccion{get;set;}
    public string Telefono{get;set;}
    public int idPuesto{get;set;}
    public string DPI{get;set;}
    public string FechaNacimiento{get;set;}
    public string FechaIngresoRegistro{get;set;}

}