using CallLogging.Data.PhoneCallRepo;
using CallLogging.Dtos;

namespace CallLogging.Services.PhoneCallService
{
    public class PhoneCallService : IPhoneCallService
    {
        private readonly IPhoneCallRepo _repo;
        public PhoneCallService(IPhoneCallRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<PhoneCallDto>> GetAllPhoneCallsAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<PhoneCallDto> GetPhoneNumberByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreatePhoneCallAsync(PhoneCallDto phoneCallDto)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePhoneCallAsync(PhoneCallDto phoneCallDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePhoneCallAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
