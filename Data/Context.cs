using CallLogging.Models;
using Microsoft.EntityFrameworkCore;

namespace CallLogging.Data
{
    public class Context : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<PhoneCall> PhoneCalls { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public Context(DbContextOptions<Context> dbContext) : base(dbContext) => Database.Migrate();
    }
}
