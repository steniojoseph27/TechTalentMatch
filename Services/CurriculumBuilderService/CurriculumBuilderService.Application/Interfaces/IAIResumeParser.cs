using CurriculumBuilderService.Application.DTOs;

namespace CurriculumBuilderService.Application.Interfaces
{
    public interface IAIResumeParser
    {
        Task<CandidateProfileDto> ParseResumeAsync(string resumeContent);
    }
}
