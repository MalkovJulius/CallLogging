using CallLogging.Dtos;

namespace CallLogging.Services.ContactService
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAllContactsAsync();
        Task<ContactDto> GetContactByIdAsync(int id);
        Task CreateContactAsync(ContactDto contactDto);
        Task UpdateContactAsync(ContactDto contactDto);
        Task DeleteContactAsync(int id);
    }
}
