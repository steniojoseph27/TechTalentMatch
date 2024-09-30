using ResumeParsingService.Application.Models;

namespace ResumeParsingService.Application.Interfaces
{
    public interface IResumeRepository
    {
        Task SaveResume(Resume resume);
        Task<Resume> GetResumeById(Guid id);
    }
}
