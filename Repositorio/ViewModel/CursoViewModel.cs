using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Model;

namespace Repositorio.ViewModel
{
   public class CursoViewModel:IViewModel<Curso>
    {

        #region Tipos primitivos desde Entidad Curso

        public int idCurso { get; set; }
        public string nombre { get; set; }
        public int duracion { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fin { get; set; }
        public Nullable<int> idAula { get; set; }

        #endregion


        public Curso ToBaseDatos()
        {
            return new Curso()
            {
                idAula = idAula,
                idCurso = idCurso,
                nombre = nombre,
                duracion = duracion,
                inicio = inicio,
                fin = fin
            };
        }

        public void FromBaseDatos(Curso modelo)
        {
            modelo.idAula = idAula;
            idCurso = modelo.idCurso;
            nombre = modelo.nombre;
            duracion = modelo.duracion;
            inicio = modelo.inicio;
            fin = modelo.fin;
        }

        public void UpdateBaseDatos(Curso modelo)
        {
            modelo.idAula = idAula;
            modelo.idCurso = idCurso;
            modelo.nombre = nombre;
            modelo.duracion = duracion;
            modelo.inicio = inicio;
            modelo.fin = fin;
        }

        public object[] GetKeys()
        {
            return new[] {(object) idCurso};
        }
    }
}
