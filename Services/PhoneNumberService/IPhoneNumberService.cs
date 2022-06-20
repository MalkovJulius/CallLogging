using CallLogging.Dtos;

namespace CallLogging.Services.PhoneNumberService
{
    public interface IPhoneNumberService
    {
        Task<IEnumerable<PhoneNumberDto>> GetAllPhoneNumbersAsync();
        Task<PhoneNumberDto> GetPhoneNumberByIdAsync(int id);
        Task CreatePhoneNumberAsync(PhoneNumberDto phoneNumberDto);
        Task UpdatePhoneNumberAsync(PhoneNumberDto phoneNumberDto);
        Task DeletePhoneNumberAsync(int id);
    }
}
