using CurriculumBuilderService.Application.DTOs;

namespace CurriculumBuilderService.Application.Interfaces
{
    public interface IJobDescriptionAnalyzer
    {
        Task<JobDescriptionDto> AnalyzeJobDescriptionAsync(string jobDescriptionContent);
    }
}
