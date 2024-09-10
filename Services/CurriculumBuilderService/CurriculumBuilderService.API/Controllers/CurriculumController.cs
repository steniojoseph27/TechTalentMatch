using CurriculumBuilderService.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using CurriculumBuilderService.Application.Interfaces;
using System.Text.Json;

namespace CurriculumBuilderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurriculumController : ControllerBase
    {
        private readonly IAIResumeParser _resumeParser;
        private readonly IJobDescriptionAnalyzer _jobDescriptionAnalyzer;
        private readonly ICurriculumServiceBuilder _curriculumBuilderService;

        public CurriculumController(IAIResumeParser resumeParser,
        IJobDescriptionAnalyzer jobDescriptionAnalyzer,
        ICurriculumServiceBuilder curriculumBuilderService)
        {
            _resumeParser = resumeParser;
            _jobDescriptionAnalyzer = jobDescriptionAnalyzer;
            _curriculumBuilderService = curriculumBuilderService;
        }

        [HttpPost]
        [Route("generate")]
        public async Task<IActionResult> GenerateCurriculum([FromBody] CurriculumRequestDto request)
        {
            var serializedResumeContent = JsonSerializer.Serialize(request.ResumeContent);
            var serializedJobDescriptionContent = JsonSerializer.Serialize(request.JobDescriptionContent);

            serializedResumeContent = serializedResumeContent.Trim('"');
            serializedJobDescriptionContent = serializedJobDescriptionContent.Trim('"');

            var candidateProfile = await _resumeParser.ParseResumeAsync(serializedResumeContent);
            var jobDescription = await _jobDescriptionAnalyzer.AnalyzeJobDescriptionAsync(serializedJobDescriptionContent);

            var curriculum = await _curriculumBuilderService.BuildCurriculumAsync(candidateProfile, jobDescription);

            return Ok(curriculum);
        }
    }
}
