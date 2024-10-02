
using ResumeParsingService.Domain.Entities;
using ResumeParsingService.Application.DTOs;

namespace ResumeParsingService.Application.Models
{
    public class ResumeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<ExperienceDto> WorkExperiences { get; set; } = new();
        public List<SkillDto> Skills { get; set; } = new();
        public List<CertificationDto> Certifications { get; set; } = new();
        public List<EducationDto> EducationHistory { get; set; } = new();
        public List<LanguageDto> Languages { get; set; } = new();
    }
}
