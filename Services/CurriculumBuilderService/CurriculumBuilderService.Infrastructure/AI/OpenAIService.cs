using CurriculumBuilderService.Application.Interfaces;
using CurriculumBuilderService.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Completions;


namespace CurriculumBuilderService.Infrastructure.AI
{
    public class OpenAIService : IOpenAIService
    {
        private readonly OpenAIAPI _openAiApi;
        private readonly OpenAISettings _settings;

        public OpenAIService(IOptions<OpenAISettings> settings)
        {
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            _openAiApi = new OpenAIAPI(_settings.ApiKey);
        }

        public async Task<string> GenerateCompletionAsync(string prompt)
        {
            var completionResult = await _openAiApi.Completions.CreateCompletionAsync(new CompletionRequest
            {
                Prompt = prompt,
                MaxTokens = 500
            });

            return completionResult.Completions.ToString();
        }
    }
}
