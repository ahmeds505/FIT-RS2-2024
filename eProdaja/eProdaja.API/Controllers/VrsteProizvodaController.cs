using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VrsteProizvodaController : BaseCRUDController<VrsteProizvoda, VrsteProizvodaSearchObject, VrsteProizvodaUpsertRequest, VrsteProizvodaUpsertRequest>
    {
        public VrsteProizvodaController(IVrsteProizvodaService service) : base(service)
        {
        }

        [Authorize(Roles = "Admin")]
        public override VrsteProizvoda Insert(VrsteProizvodaUpsertRequest request)
        {
            return base.Insert(request);
        }

        [AllowAnonymous]
        public override PagedResult<VrsteProizvoda> GetList([FromQuery] VrsteProizvodaSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }
    }
}
