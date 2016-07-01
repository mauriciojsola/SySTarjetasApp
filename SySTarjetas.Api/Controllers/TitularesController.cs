using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
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
        public IEnumerable<TitularViewModel> List()
        {
            return TitularRepository.GetAll().OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
               .Select(x => new TitularViewModel { Apellido = x.Apellido, Nombre = x.Nombre, Id = x.Id }).ToArray();

        }

        [HttpGet]
        [Route("select")]
        public IEnumerable<KeyValueModel> Select()
        {
            return TitularRepository.GetAll().OrderBy(x => x.Apellido).ThenBy(x => x.Nombre).ToList()
                .Select(x => new KeyValueModel { Key = x.Id.ToString(), Value = string.Format("{0} {1}", x.Apellido, x.Nombre) });

        }

        [HttpGet]
        [Route("{id:int}")]
        public TitularViewModel Get(int id)
        {
            var cuponViewModel = new TitularViewModel();
            var cupon = TitularRepository.GetById(id);
            if (cupon != null)
            {
                cuponViewModel = Mapper.Map<TitularViewModel>(cupon);
            }
            return cuponViewModel;
        }
    }

}