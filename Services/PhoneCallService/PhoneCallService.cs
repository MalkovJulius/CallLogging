using CallLogging.Data.ContactRepo;
using CallLogging.Data.PhoneCallRepo;
using CallLogging.Data.PhoneNumberRepo;
using CallLogging.Dtos;
using CallLogging.Models;
using Microsoft.EntityFrameworkCore;

namespace CallLogging.Services.PhoneCallService
{
    public class PhoneCallService : IPhoneCallService
    {
        private readonly IPhoneCallRepo _phoneCallRepo;
        private readonly IPhoneNumberRepo _phoneNumberRepo;
        public PhoneCallService(IPhoneCallRepo phoneCallRepo, IPhoneNumberRepo phoneNumberRepo)
        {
            _phoneCallRepo = phoneCallRepo;
            _phoneNumberRepo = phoneNumberRepo;
        }

        //TODO: do a pagination
        public async Task<IEnumerable<PhoneCallDto>> GetAllPhoneCallsAsync()
        {
            return await _phoneCallRepo.GetAll()
                .Take(10)
                .Select(phoneCall => new PhoneCallDto
                {
                    Id = phoneCall.Id,
                    DateStart = phoneCall.DateStart,
                    DateEnd = phoneCall.DateEnd,
                    CallLength = phoneCall.CallLength,

                    CallerId = phoneCall.PhoneNumberOfCaller.Contact.Id,
                    NameCaller = phoneCall.PhoneNumberOfCaller.Contact.Name,
                    SurnameCaller = phoneCall.PhoneNumberOfCaller.Contact.Surname,
                    PhoneNumberCallerId = phoneCall.PhoneNumberOfCaller.Id,
                    PhoneNumberCaller = phoneCall.PhoneNumberOfCaller.Number,

                    RecipientId = phoneCall.PhoneNumberOfReceiver.Contact.Id,
                    NameRecipient = phoneCall.PhoneNumberOfReceiver.Contact.Name,
                    SurnameRecipient = phoneCall.PhoneNumberOfReceiver.Contact.Surname,
                    PhoneNumberRecipientId = phoneCall.PhoneNumberOfReceiver.Id,
                    PhoneNumberRecipient = phoneCall.PhoneNumberOfReceiver.Number
                })
                .ToListAsync();
        }

        public async Task<PhoneCallDto?> GetPhoneCallByIdAsync(int id)
        {
            var phoneCall = await _phoneCallRepo.GetByIdAsync(id);
            return phoneCall == null
                ? null
                : new PhoneCallDto
                {
                    Id = phoneCall.Id,
                    DateStart = phoneCall.DateStart,
                    DateEnd = phoneCall.DateEnd,
                    CallLength = phoneCall.CallLength,

                    CallerId = phoneCall.PhoneNumberOfCaller.Contact.Id,
                    NameCaller = phoneCall.PhoneNumberOfCaller.Contact.Name,
                    SurnameCaller = phoneCall.PhoneNumberOfCaller.Contact.Surname,
                    PhoneNumberCallerId = phoneCall.PhoneNumberOfCaller.Id,
                    PhoneNumberCaller = phoneCall.PhoneNumberOfCaller.Number,

                    RecipientId = phoneCall.PhoneNumberOfReceiver.Contact.Id,
                    NameRecipient = phoneCall.PhoneNumberOfReceiver.Contact.Name,
                    SurnameRecipient = phoneCall.PhoneNumberOfReceiver.Contact.Surname,
                    PhoneNumberRecipientId = phoneCall.PhoneNumberOfReceiver.Id,
                    PhoneNumberRecipient = phoneCall.PhoneNumberOfReceiver.Number
                };
        }

        public async Task CreatePhoneCallAsync(PhoneCallDto phoneCallDto)
        {
            //TODO: do a uniqueness check
            if (phoneCallDto == null) return;

            if (phoneCallDto.PhoneNumberCallerId == null || phoneCallDto.PhoneNumberRecipientId == null)
            {
                throw new ArgumentNullException("Ids of phone numbers are null");
            }

            var numberCaller = await _phoneNumberRepo.GetByIdAsync((int)phoneCallDto.PhoneNumberCallerId);
            var numberRecipient = await _phoneNumberRepo.GetByIdAsync((int)phoneCallDto.PhoneNumberRecipientId);

            if (numberCaller == null || numberRecipient == null)
            {
                throw new KeyNotFoundException("Not exist this phone numbers");
            }

            await _phoneCallRepo.CreateAsync(new PhoneCall
            {
                Id = phoneCallDto.Id,
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now,
                CallLength = phoneCallDto.CallLength,
                PhoneNumberOfCaller = numberCaller,
                PhoneNumberOfReceiver = numberRecipient
            });
        }

        public async Task UpdatePhoneCallAsync(PhoneCallDto phoneCallDto)
        {
            var phoneCall = await _phoneCallRepo.GetByIdAsync(phoneCallDto.Id);
            if (phoneCall == null) throw new KeyNotFoundException();

            phoneCall.DateStart = (DateTime)phoneCallDto.DateStart;
            phoneCall.DateEnd = (DateTime)phoneCallDto.DateEnd;
            phoneCall.CallLength = phoneCallDto.CallLength;

            await _phoneCallRepo.UpdateAsync(phoneCall);
        }

        public async Task DeletePhoneCallAsync(int id)
        {
            var phoneCall = await _phoneCallRepo.GetByIdAsync(id);
            if (phoneCall == null) return;

            await _phoneCallRepo.DeleteAsync(phoneCall);
        }
    }
}
