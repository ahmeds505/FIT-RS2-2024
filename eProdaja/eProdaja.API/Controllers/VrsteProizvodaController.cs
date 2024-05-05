using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VrsteProizvodaController : BaseController<VrsteProizvoda, VrsteProizvodaSearchObject>
    {
        public VrsteProizvodaController(IVrsteProizvodaService service) : base(service)
        {
        }

       
    }
}
