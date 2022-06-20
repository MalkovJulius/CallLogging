using CallLogging.Models;
using Microsoft.EntityFrameworkCore;

namespace CallLogging.Data.ConferenceRepo
{
    public class ConferenceRepo : IConferenceRepo
    {
        private readonly Context _context;
        public ConferenceRepo(Context context)
        {
            _context = context;
        }

        public IQueryable<Conference> GetAll()
        {
            return _context.Conferences;
        }

        public async Task<Conference> GetByIdAsync(int id)
        {
            return await _context.Conferences.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Conference instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            await _context.Conferences.AddAsync(instance);
        }

        public async Task DeleteAsync(Conference instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            _context.Conferences.Remove(instance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Conference instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            _context.Conferences.Update(instance);
            await _context.SaveChangesAsync();
        }
    }
}
