using CurriculumBuilderService.Application.DTOs;
using CurriculumBuilderService.Application.Interfaces;
using CurriculumBuilderService.Domain.Entities;
using CurriculumBuilderService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurriculumBuilderService.Application.Services
{
    public class JobDescriptionAnalyzer : IJobDescriptionAnalyzer
    {
        private readonly IOpenAIService _openAIService;

        public JobDescriptionAnalyzer(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<JobDescriptionDto> AnalyzeJobDescriptionAsync(string jobDescriptionContent)
        {
            var response = await _openAIService.GenerateCompletionAsync($"Extract key skills from this job description:\n{jobDescriptionContent}");
            return ParseJobDescription(response);
        }

        private JobDescriptionDto ParseJobDescription(string response)
        {
            var jobDescription = JsonSerializer.Deserialize<JobDescription>(response);

            var jobDescriptionDto = new JobDescriptionDto
            {
                Title = jobDescription.Title,
                RequiredSkills = jobDescription.RequiredSkills?.Select(skill => new Skill { Name = skill.Name }).ToList(),
                Responsibilities = jobDescription.Responsibilities?.Select(resp => new Responsibility { Description = resp.Description }).ToList(),
                Qualifications = jobDescription.Qualifications?.Select(qual => new Qualification { Description = qual.Description }).ToList()
            };

            return jobDescriptionDto;
        }
    }
}
