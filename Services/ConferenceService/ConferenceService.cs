using CallLogging.Data.ConferenceRepo;
using CallLogging.Dtos;

namespace CallLogging.Services.ConferenceService
{
    public class ConferenceService : IConferenceService
    {
        public readonly IConferenceRepo _repo;
        public ConferenceService(IConferenceRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ConferenceDto>> GetAllConferencesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ConferenceDto> GetConferenceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateConferenceAsync(ConferenceDto conferenceDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteConferenceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateConferenceAsync(ConferenceDto conferenceDto)
        {
            throw new NotImplementedException();
        }
    }
}
