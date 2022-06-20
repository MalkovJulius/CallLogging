using CallLogging.Models;
using Microsoft.EntityFrameworkCore;

namespace CallLogging.Data.PhoneNumberRepo
{
    public class PhoneNumberRepo : IPhoneNumberRepo
    {
        private readonly Context _context;
        public PhoneNumberRepo(Context context)
        {
            _context = context;
        }

        public IQueryable<PhoneNumber> GetAll()
        {
            return _context.PhoneNumbers;
        }

        public async Task<PhoneNumber> GetByIdAsync(int id)
        {
            return await _context.PhoneNumbers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(PhoneNumber instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            await _context.PhoneNumbers.AddAsync(instance);
        }

        public async Task DeleteAsync(PhoneNumber instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            _context.PhoneNumbers.Remove(instance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PhoneNumber instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            _context.PhoneNumbers.Update(instance);
            await _context.SaveChangesAsync();
        }
    }
}
