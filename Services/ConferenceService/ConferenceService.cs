using CallLogging.Data.ConferenceRepo;
using CallLogging.Data.PhoneNumberRepo;
using CallLogging.Dtos;
using CallLogging.Models;
using Microsoft.EntityFrameworkCore;

namespace CallLogging.Services.ConferenceService
{
    public class ConferenceService : IConferenceService
    {
        public readonly IConferenceRepo _conferenceRepo;
        public readonly IPhoneNumberRepo _numberRepo;
        public ConferenceService(IConferenceRepo conferenceRepo, IPhoneNumberRepo numberRepo)
        {
            _conferenceRepo = conferenceRepo;
            _numberRepo = numberRepo;
        }

        public async Task<IEnumerable<ConferenceDto>> GetAllConferencesAsync()
        {
            //TODO: should make pagination
            return await _conferenceRepo.GetAll()
                .Take(10)
                .Select(conference => new ConferenceDto
                {
                    Id = conference.Id,
                    PhoneNumberInitial = conference.InitialPhoneNumber.Contact.Name + " " + conference.InitialPhoneNumber.Contact.Surname,
                    PhoneNumberInitialId = conference.InitialPhoneNumber.Id
                })
                .ToListAsync();
        }

        public async Task<ConferenceDto> GetConferenceByIdAsync(int id)
        {
            var conference = await _conferenceRepo.GetByIdAsync(id);
            return conference == null ?
                throw new KeyNotFoundException(nameof(conference)) :
                new ConferenceDto { 
                    Id = conference.Id,
                    PhoneNumberInitial = conference.InitialPhoneNumber.Contact.Name + " " + conference.InitialPhoneNumber.Contact.Surname,
                    PhoneNumberInitialId = conference.InitialPhoneNumber.Id
                };
        }

        public async Task CreateConferenceAsync(ConferenceDto conferenceDto)
        {
            //TODO: do a uniqueness check
            if (conferenceDto == null) throw new ArgumentNullException(nameof(conferenceDto));

            var phoneNumber = await _numberRepo.GetByIdAsync(conferenceDto.PhoneNumberInitialId);
            if (phoneNumber == null) throw new KeyNotFoundException(nameof(phoneNumber));

            await _conferenceRepo.CreateAsync(new Conference
            {
                InitialPhoneNumber = phoneNumber,
                PhoneNumbers = new List<PhoneNumber>()
            });
        }

        public async Task UpdateConferenceAsync(ConferenceDto conferenceDto)
        {
            if (conferenceDto == null) throw new ArgumentNullException(nameof(conferenceDto));

            var conference = await _conferenceRepo.GetByIdAsync(conferenceDto.Id);
            if (conference == null) throw new KeyNotFoundException();

            conference.InitialPhoneNumber.Id = conferenceDto.PhoneNumberInitialId;
            await _conferenceRepo.UpdateAsync(conference);
        }

        public async Task DeleteConferenceAsync(int id)
        {
            var conference = await _conferenceRepo.GetByIdAsync(id);
            if (conference == null) throw new KeyNotFoundException(nameof(conference));

            await _conferenceRepo.DeleteAsync(conference);
        }
    }
}
