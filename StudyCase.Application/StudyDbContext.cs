using Microsoft.EntityFrameworkCore;
using StudyCase.Application.Entities;

namespace StudyCase.Application
{
    public class StudyDbContext: DbContext
    {
        public StudyDbContext(DbContextOptions<StudyDbContext> options)
         : base(options)
        {
        }
        public DbSet<QueueMessage> QueueMessages { get; set; }
    }
}
