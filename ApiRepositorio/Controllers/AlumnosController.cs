using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Practices.Unity;
using Repositorio.Model;
using Repositorio.Repositorio;
using Repositorio.ViewModel;

namespace ApiRepositorio.Controllers
{
    public class AlumnosController : ApiController
    {


        private CentroFormacionEntities context;

        [Dependency] // con este decorador le indico a Unity que inyecte
        // instanciar Repositorio
        public IRepositorio<Alumno, AlumnoViewModel> repo { get; private set; }


        // Construyo mi contexto
        // Construyo mi repositorio
        //public AlumnosController()
        //{
        //    context = new CentroFormacionEntities();
        //    repo = new RepositorioEntity<Alumno, AlumnoViewModel>(context);
        //}

        public ICollection<AlumnoViewModel> Get()
        {
            return repo.Get();
        }

        [ResponseType(typeof (AlumnoViewModel))]

        public IHttpActionResult Get(String id)
        {
            var data = repo.Get(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        public IHttpActionResult Get(String dni,String nombre)
        {
            var data = repo.Get(o=>o.dni.Contains(dni)||o.nombre.Contains(nombre));
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // POST: api/Alumno
        [ResponseType(typeof(AlumnoViewModel))]
        public IHttpActionResult PostAlumno(AlumnoViewModel alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Actualizar(alumno);

            return Created("DefaultApi", alumno);
        }

        // DELETE: api/Alumno/5
        [ResponseType(typeof(AlumnoViewModel))]
        public IHttpActionResult DeleteAlumno(int id)
        {
            var  alumno = repo.Get(id);
            if (alumno == null)
            {
                return NotFound();
            }
            repo.Borrar(alumno);

            return Ok(alumno);
        }

    }
}
