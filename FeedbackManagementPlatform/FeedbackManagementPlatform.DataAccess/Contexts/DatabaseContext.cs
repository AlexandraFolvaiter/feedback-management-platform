using FeedbackManagementPlatform.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackManagementPlatform.DataAccess.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<FeedbackForm> Forms { get; set; }
    }
}