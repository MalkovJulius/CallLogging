using CallLogging.Data.ContactRepo;
using CallLogging.Dtos;

namespace CallLogging.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IContactRepo _repo;
        public ContactService(IContactRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ContactDto>> GetAllContactsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ContactDto> GetContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateContactAsync(ContactDto contactDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateContactAsync(ContactDto contactDto)
        {
            throw new NotImplementedException();
        }
    }
}
