using CurriculumBuilderService.Domain.ValueObjects;

namespace CurriculumBuilderService.Application.DTOs
{
    public class CandidateProfileDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Skill>? Skills { get; set; }
        public List<Qualification>? Education { get; set; }
        public List<Experience>? WorkExperience { get; set; }
        public List<Certification>? Certifications { get; set; }
        public List<AdditionalAccomplishment>? Accomplishments { get; set; }
        public List<Language>? Languages { get; set; }
    }
}
