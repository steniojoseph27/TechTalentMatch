using CurriculumBuilderService.Application.DTOs;
using CurriculumBuilderService.Application.Interfaces;
using CurriculumBuilderService.Domain.Entities;
using CurriculumBuilderService.Domain.ValueObjects;
using System.Text.Json;

namespace CurriculumBuilderService.Application.Services
{
    public class AIResumeParser : IAIResumeParser
    {
        private readonly IOpenAIService _openAIService;

        public AIResumeParser(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<CandidateProfileDto> ParseResumeAsync(string resumeContent)
        {
            var response = await _openAIService.GenerateCompletionAsync($"Extract profile details from this resume:\n{resumeContent}");
            return ParseCandidateProfile(response);
        }
        private CandidateProfileDto ParseCandidateProfile(string response)
        {
            var candidateProfile = JsonSerializer.Deserialize<CandidateProfile>(response);

            var candidateProfileDto = new CandidateProfileDto
            {
                Name = candidateProfile.Name,
                Email = candidateProfile.Email,

                Skills = candidateProfile.Skills?.Select(skill => new Skill { Name = skill.Name }).ToList(),
                Education = candidateProfile.Education?.Select(edu => new Qualification { Description = edu.Description }).ToList(),
                WorkExperience = candidateProfile.WorkExperience?.Select(exp => new Experience
                {
                    JobTitle = exp.JobTitle,
                    CompanyName = exp.CompanyName,
                    StartDate = exp.StartDate,
                    EndDate = exp.EndDate,
                    Responsibilities = exp.Responsibilities
                }).ToList(),
                Certifications = candidateProfile.Certifications?.Select(cert => new Certification
                {
                    Name = cert.Name,
                    IssuingOrganization = cert.IssuingOrganization,
                    DateObtained = cert.DateObtained,
                    ExpirationDate = cert.ExpirationDate
                }).ToList(),
                Accomplishments = candidateProfile.Accomplishments?.Select(acc => new AdditionalAccomplishment
                {
                    Title = acc.Title,
                    Description = acc.Description,
                    Date = acc.Date
                }).ToList(),
                Languages = candidateProfile.Languages?.Select(lang => new Language
                {
                    Name = lang.Name,
                    ProficiencyLevel = lang.ProficiencyLevel
                }).ToList()
            };

            return candidateProfileDto;
        }
    }
}
