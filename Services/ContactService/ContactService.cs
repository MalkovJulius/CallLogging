using CallLogging.Data.ContactRepo;
using CallLogging.Dtos;
using CallLogging.Models;
using Microsoft.EntityFrameworkCore;

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
            //TODO: should make pagination
            return await _repo.GetAll()
                .Take(10)
                .Select(contact => new ContactDto { Id = contact.Id, Name = contact.Name, Surname = contact.Surname })
                .ToListAsync();
        }

        public async Task<ContactDto> GetContactByIdAsync(int id)
        {
            var contact = await _repo.GetByIdAsync(id);
            return contact == null ?
                throw new KeyNotFoundException(nameof(contact)) :
                new ContactDto { Id = contact.Id, Name = contact.Name, Surname = contact.Surname };
        }

        public async Task CreateContactAsync(ContactDto contactDto)
        {
            //TODO: do a uniqueness check
            if (contactDto == null) throw new ArgumentNullException(nameof(contactDto));

            await _repo.CreateAsync(new Contact
            {
                Name = contactDto.Name,
                Surname = contactDto.Surname,
                PhoneNumbers = new List<PhoneNumber>()
            });
        }

        public async Task UpdateContactAsync(ContactDto contactDto)
        {
            if (contactDto == null) throw new ArgumentNullException(nameof(contactDto));

            var contact = await _repo.GetByIdAsync(contactDto.Id);
            if (contact == null) throw new KeyNotFoundException();

            contact.Name = contactDto.Name;
            contact.Surname = contactDto.Surname;
            await _repo.UpdateAsync(contact);
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _repo.GetByIdAsync(id);
            if (contact == null) throw new KeyNotFoundException(nameof(contact));

            await _repo.DeleteAsync(contact);
        }
    }
}
