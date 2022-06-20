using CallLogging.Models;
using Microsoft.EntityFrameworkCore;

namespace CallLogging.Data.PhoneCallRepo
{
    public class PhoneCallRepo : IPhoneCallRepo
    {
        private readonly Context _context;
        public PhoneCallRepo(Context context)
        {
            _context = context;
        }

        public IQueryable<PhoneCall> GetAll()
        {
            return _context.PhoneCalls;
        }

        public async Task<PhoneCall> GetByIdAsync(int id)
        {
            return await _context.PhoneCalls.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(PhoneCall instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            await _context.PhoneCalls.AddAsync(instance);
        }

        public async Task DeleteAsync(PhoneCall instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            _context.PhoneCalls.Remove(instance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PhoneCall instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            _context.PhoneCalls.Update(instance);
            await _context.SaveChangesAsync();
        }
    }
}
