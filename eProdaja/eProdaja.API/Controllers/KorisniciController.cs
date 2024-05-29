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
    public class KorisniciController : BaseCRUDController<Model.Korisnici, KorisniciSearchObject, KorisniciInsert, KorisniciUpdate>
    {
        IKorisniciService _service;
        public KorisniciController(IKorisniciService service) : base(service) 
        {
            _service = service;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public Model.Korisnici Login(string username, string password)
        {
            return _service.Login(username, password);
        }
    }
}
