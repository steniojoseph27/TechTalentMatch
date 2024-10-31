using ResumeParsingService.Application.Models;

namespace ResumeParsingService.Application.Interfaces
{
    public interface IResumeRepository
    {
        Task SaveResume(ResumeDto resumeDto);
        Task<ResumeDto> GetResumeById(Guid id);
    }
}
