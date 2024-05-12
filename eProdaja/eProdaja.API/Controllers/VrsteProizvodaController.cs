using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
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

       
    }
}
