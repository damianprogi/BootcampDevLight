using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arreglos_Listas.Class
{
    internal class Persona
    {
        private string Nombre { get; set; }
        private string Apellido { get; set; }      
        private DateTime FechaNacimiento { get; set; }
    
        public Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public Persona(string nombre, string apellido, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;

        }

        public string NombreCompleto()
        {
            return base.ToString() + ' ' + Apellido;
        }

        public int Edad()
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Today - FechaNacimiento;
            DateTime edad = new DateTime(ts.Ticks);
            return edad.Year - 1;
        }

        public bool isMayorEdad()
        {
            return (Edad() >= 18) ? true : false;
        }
    }
}






