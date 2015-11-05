using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Model;

namespace Repositorio.ViewModel
{
    public class AlumnoViewModel:IViewModel<Alumno>
    {
        // es un intermediario entre la vista y el modelo de negocio
        // Alta, Baja, Cambio

        public string dni { get; set; }

        public string nombre { get; set; }

        public List<String> Cursos { get; set; }

        // transforma objeto view model en objeto Alumno
        public Alumno ToBaseDatos()
        {
            var al = new Alumno()
            {
                dni=dni,
                nombre=nombre
            };

            return al;
        }

        public void FromBaseDatos(Alumno modelo)
        {
            // actualizar
            dni = dni;
            nombre = modelo.nombre;
        }

        public void UpdateBaseDatos(Alumno modelo)
        {
            modelo.dni = dni;
            modelo.nombre = nombre;
        }

        // se agrega la llave primaria separado con comas
        public object[] GetKeys()
        {
            return new[] {dni};
        }
    }
}
