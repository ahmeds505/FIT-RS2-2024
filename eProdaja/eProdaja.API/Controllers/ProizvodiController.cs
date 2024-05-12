using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : BaseCRUDController<Proizvodi, ProizvodiSearchObject, ProizvodiInsert, ProizvodiUpdate>
    {
        protected new IProizvodiService _service; 
        public ProizvodiController(IProizvodiService service) : base(service)
        {
            _service = service;
        }

        [HttpPut("{id}/activate")]
        public Proizvodi Activate(int id)
        {
            return _service.Activate(id);
        }
    }
}
