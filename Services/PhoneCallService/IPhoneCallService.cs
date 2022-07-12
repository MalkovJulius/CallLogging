using CallLogging.Dtos;

namespace CallLogging.Services.PhoneCallService
{
    public interface IPhoneCallService
    {
        Task<IEnumerable<PhoneCallDto>> GetAllPhoneCallsAsync();
        Task<PhoneCallDto> GetPhoneCallByIdAsync(int id);
        Task CreatePhoneCallAsync(PhoneCallDto phoneCallDto);
        Task UpdatePhoneCallAsync(PhoneCallDto phoneCallDto);
        Task DeletePhoneCallAsync(int id);
    }
}
