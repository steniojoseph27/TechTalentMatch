using ResumeParsingService.Application.Interfaces;
using ResumeParsingService.Application.Models;
using ResumeParsingService.Infrastructure.Data;

namespace ResumeParsingService.Infrastructure.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly ResumeParsingDbContext _context;

        public ResumeRepository(ResumeParsingDbContext context)
        {
            _context = context;
        }

        public async Task SaveResume(Resume resume)
        {
            _context.Resumes.Add(resume);
            await _context.SaveChangesAsync();
        }

        public async Task<Resume> GetResumeById(Guid id)
        {
            return await _context.Resumes.FindAsync(id);
        }
    }
}
