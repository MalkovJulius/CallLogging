using CallLogging.Dtos;
using CallLogging.Services.ContactService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly IContactService _service;
        public ContactController(IContactService service)
        {
            _service = service;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IEnumerable<ContactDto>> GetAll()
        {
            return await _service.GetAllContactsAsync();
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<ContactDto> Get(int id)
        {
            return await _service.GetContactByIdAsync(id);
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task Create(ContactDto dto)
        {
            await _service.CreateContactAsync(dto);
        }

        // PUT api/<ContactController>
        [HttpPut]
        public async Task Update(ContactDto dto)
        {
            await _service.UpdateContactAsync(dto);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteContactAsync(id);
        }
    }
}
