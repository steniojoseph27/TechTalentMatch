using CurriculumBuilderService.Application.DTOs;
using CurriculumBuilderService.Application.Interfaces;
using CurriculumBuilderService.Domain.ValueObjects;

namespace CurriculumBuilderService.Application.Services
{
    public class CurriculumServiceBuilder : ICurriculumServiceBuilder
    {
        private readonly IAIResumeParser _resumeParser;
        private readonly IJobDescriptionAnalyzer _jobDescriptionAnalyzer;

        public CurriculumServiceBuilder(IAIResumeParser resumeParser, IJobDescriptionAnalyzer jobDescriptionAnalyzer)
        {
            _resumeParser = resumeParser;
            _jobDescriptionAnalyzer = jobDescriptionAnalyzer;
        }

        public async Task<CurriculumDto> BuildCurriculumAsync(CandidateProfileDto candidateProfile, JobDescriptionDto jobDescription)
        {
            var curriculum = new CurriculumDto
            {
                ProfessionalHeader = candidateProfile.Name,
                ProfessionalSummary = $"Highly skilled in {string.Join(", ", candidateProfile.Skills.Select(skill => skill.Name))}",
                Education = candidateProfile.Education?.Select(edu => new Qualification { Description = edu.Description }).ToList(),
                WorkExperience = candidateProfile.WorkExperience?.Select(exp => new Experience
                {
                    JobTitle = exp.JobTitle,
                    CompanyName = exp.CompanyName,
                    StartDate = exp.StartDate,
                    EndDate = exp.EndDate,
                    Responsibilities = exp.Responsibilities
                }).ToList(),
                Skills = candidateProfile.Skills?.Select(skill => new Skill { Name = skill.Name }).ToList(),
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

            return await Task.FromResult(curriculum);
        }
    }
}
