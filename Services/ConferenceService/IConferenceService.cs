using CallLogging.Dtos;

namespace CallLogging.Services.ConferenceService
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceDto>> GetAllConferencesAsync();
        Task<ConferenceDto?> GetConferenceByIdAsync(int id);
        Task CreateConferenceAsync(ConferenceDto conferenceDto);
        Task UpdateConferenceAsync(ConferenceDto conferenceDto);
        Task DeleteConferenceAsync(int id);
    }
}
