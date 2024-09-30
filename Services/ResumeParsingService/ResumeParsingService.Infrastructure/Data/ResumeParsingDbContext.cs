using Microsoft.EntityFrameworkCore;
using ResumeParsingService.Application.Models;

namespace ResumeParsingService.Infrastructure.Data
{
    public class ResumeParsingDbContext : DbContext
    {
        public DbSet<Resume> Resumes { get; set; }

        public ResumeParsingDbContext(DbContextOptions<ResumeParsingDbContext> options) : base(options) { }
    }
}
