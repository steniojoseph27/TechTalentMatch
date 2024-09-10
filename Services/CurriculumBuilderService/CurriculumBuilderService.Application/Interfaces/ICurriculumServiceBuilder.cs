using CurriculumBuilderService.Application.DTOs;

namespace CurriculumBuilderService.Application.Interfaces
{
    public interface ICurriculumServiceBuilder
    {
        Task<CurriculumDto> BuildCurriculumAsync(CandidateProfileDto candidateProfile, JobDescriptionDto jobDescription);
    }
}
