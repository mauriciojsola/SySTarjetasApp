using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using SySTarjetas.Api.Models;
using SySTarjetas.Core;
using SySTarjetas.Core.Repository;
using WebApi.OutputCache.V2;

namespace SySTarjetas.Api.Controllers
{
    [RoutePrefix("api/comercios")]
    public class ComerciosController : ApiControllerBase
    {
        public IComercioRepository ComercioRepository { get; set; }

        [HttpGet]
        [Route("list")]
        [CacheOutput(ClientTimeSpan = 10, ServerTimeSpan = 10)]
        public IList<ComercioViewModel> List()
        {
            return ComercioRepository.GetAll().OrderBy(x => x.RazonSocial).ToList()
                .Select(x => MapToModel(x)).ToList();

        }

        private ComercioViewModel MapToModel(Comercio comercio)
        {
            return Mapper.Map<ComercioViewModel>(comercio);
        }
    }

}