using CallLogging.Data.PhoneNumberRepo;
using CallLogging.Dtos;

namespace CallLogging.Services.PhoneNumberService
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IPhoneNumberRepo _repo;
        public PhoneNumberService(IPhoneNumberRepo repo)
        {
            _repo = repo;
        }

        //TODO: do a pagination
        public async Task<IEnumerable<PhoneNumberDto>> GetAllPhoneNumbersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PhoneNumberDto?> GetPhoneNumberByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreatePhoneNumberAsync(PhoneNumberDto phoneNumberDto)
        {
            //TODO: do a uniqueness check
            throw new NotImplementedException();
        }

        public async Task DeletePhoneNumberAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePhoneNumberAsync(PhoneNumberDto phoneNumberDto)
        {
            throw new NotImplementedException();
        }
    }
}
