using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : ControllerBase
    {
        protected IKorisniciService _service;
        public KorisniciController(IKorisniciService service) 
        {
            _service = service;
        }

       [HttpGet]
       public List<Korisnici> GetList()
        {
            return _service.GetList();
        }

        [HttpPost]
        public Korisnici Insert(KorisniciInsert item) 
        { 
            return _service.Insert(item);

        }

        [HttpPut("{id}")]
        public Korisnici Update(int id, KorisniciUpdate item)
        {
            return _service.Update(id, item);
        }
    }
}
