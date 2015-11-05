using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Repositorio.Model;
using Repositorio.Repositorio;
using Repositorio.ViewModel;
using Unity.WebApi;

namespace ApiRepositorio
{
    public static class UnityConfig
    {

        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            // crear un dbcontext con el constructor de CentroFormacionEntities
            container.RegisterType<DbContext, CentroFormacionEntities>(); 

            container.RegisterType<IRepositorio<Alumno,AlumnoViewModel>,
            RepositorioEntity<Alumno, AlumnoViewModel>>();

            container.RegisterType < IRepositorio<Curso, CursoViewModel>,
            RepositorioEntity<Curso, CursoViewModel>>();

            // para escribir logs
            // para enviar emails



            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            // para resolver dependencias, utiliza este contenedor

        }
    }
}