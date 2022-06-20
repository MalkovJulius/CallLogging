using CallLogging.Models;
using Microsoft.EntityFrameworkCore;

namespace CallLogging.Data.ContactRepo
{
    public class ContactRepo : IContactRepo
    {
        private readonly Context _context;
        public ContactRepo(Context context)
        {
            _context = context;
        }

        public IQueryable<Contact> GetAll()
        {
            return _context.Contacts;
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Contact instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            await _context.Contacts.AddAsync(instance);
        }

        public async Task DeleteAsync(Contact instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            _context.Contacts.Remove(instance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            _context.Contacts.Update(instance);
            await _context.SaveChangesAsync();
        }
    }
}
