using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SySTarjetas.Api.Models;
using SySTarjetas.Core.Repository;

namespace SySTarjetas.Api.Controllers
{
    [RoutePrefix("api/titulares")]
    public class TitularesController : ApiControllerBase
    {
        public ITitularRepository TitularRepository { get; set; }

        [HttpGet]
        [Route("list")]
        public IList<TitularViewModel> List()
        {
            return TitularRepository.GetAll().OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
               .Select(x => new TitularViewModel { Apellido = x.Apellido, Nombre = x.Nombre, Id = x.Id }).ToList();

        }
    }

}