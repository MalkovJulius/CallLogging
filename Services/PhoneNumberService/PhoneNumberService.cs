using CallLogging.Data.ContactRepo;
using CallLogging.Data.PhoneNumberRepo;
using CallLogging.Dtos;
using CallLogging.Models;
using Microsoft.EntityFrameworkCore;

namespace CallLogging.Services.PhoneNumberService
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IPhoneNumberRepo _phoneNumberRepo;
        private readonly IContactRepo _contactRepo;
        public PhoneNumberService(IPhoneNumberRepo phoneNumberRepo, IContactRepo contactRepo)
        {
            _phoneNumberRepo = phoneNumberRepo;
            _contactRepo = contactRepo;
        }

        public async Task<IEnumerable<PhoneNumberDto>> GetAllPhoneNumbersAsync()
        {
            //TODO: should make pagination
            return await _phoneNumberRepo.GetAll()
                .Take(10)
                .Select(phoneNumber => new PhoneNumberDto
                {
                    Id = phoneNumber.Id,
                    PhoneNumber = phoneNumber.Number,
                    OwnerId = phoneNumber.Contact.Id,
                    NameOwner = phoneNumber.Contact.Name,
                    SurnameOwner = phoneNumber.Contact.Surname
                })
                .ToListAsync();
        }

        public async Task<PhoneNumberDto> GetPhoneNumberByIdAsync(int id)
        {
            var phoneNumber = await _phoneNumberRepo.GetByIdAsync(id);
            return phoneNumber == null ?
                throw new KeyNotFoundException(nameof(phoneNumber)) :
                new PhoneNumberDto
                {
                    Id = phoneNumber.Id,
                    PhoneNumber = phoneNumber.Number,
                    OwnerId = phoneNumber.Contact.Id,
                    NameOwner = phoneNumber.Contact.Name,
                    SurnameOwner = phoneNumber.Contact.Surname
                };
        }

        public async Task CreatePhoneNumberAsync(PhoneNumberDto phoneNumberDto)
        {
            //TODO: do a uniqueness check
            if (phoneNumberDto == null) throw new ArgumentNullException(nameof(phoneNumberDto));

            var contact = await _contactRepo.GetByIdAsync(phoneNumberDto.OwnerId);
            if (contact == null) throw new KeyNotFoundException("Not found contact");

            await _phoneNumberRepo.CreateAsync(new PhoneNumber
            {
                Number = phoneNumberDto.PhoneNumber,
                Contact = contact
            });
        }

        public async Task UpdatePhoneNumberAsync(PhoneNumberDto phoneNumberDto)
        {
            if (phoneNumberDto == null) throw new ArgumentNullException(nameof(phoneNumberDto));

            var phoneNumber = await _phoneNumberRepo.GetByIdAsync(phoneNumberDto.Id);
            if (phoneNumber == null) throw new KeyNotFoundException("Not found phone number");

            phoneNumber.Number = phoneNumberDto.PhoneNumber;
            phoneNumber.Contact.Id = phoneNumberDto.OwnerId;//it is needed to check, maybe it is better to assign an object
            await _phoneNumberRepo.UpdateAsync(phoneNumber);
        }

        public async Task DeletePhoneNumberAsync(int id)
        {
            var phoneNumber = await _phoneNumberRepo.GetByIdAsync(id);
            if (phoneNumber == null) throw new KeyNotFoundException(nameof(phoneNumber));

            await _phoneNumberRepo.DeleteAsync(phoneNumber);
        }
    }
}
