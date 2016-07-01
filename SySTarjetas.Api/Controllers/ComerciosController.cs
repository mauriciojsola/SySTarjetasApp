using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using SySTarjetas.Api.Models;
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
                .Select(x => Mapper.Map<ComercioViewModel>(x)).ToList();

        }

        [HttpGet]
        [Route("select")]
        public IEnumerable<KeyValueModel> Select()
        {
            return ComercioRepository.GetAll().OrderBy(x => x.RazonSocial).ToList()
                .Select(x => new KeyValueModel { Key = x.Id.ToString(), Value = x.RazonSocial });

        }

    }

}