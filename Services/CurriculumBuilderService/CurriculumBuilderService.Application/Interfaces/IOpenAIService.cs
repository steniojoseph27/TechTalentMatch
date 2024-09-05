namespace CurriculumBuilderService.Application.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GenerateCompletionAsync(string prompt);
    }
}
