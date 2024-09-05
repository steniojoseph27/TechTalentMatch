using CurriculumBuilderService.Domain.ValueObjects;

namespace CurriculumBuilderService.Application.DTOs
{
    public class CurriculumDto
    {
        public string ProfessionalHeader { get; set; } = string.Empty;
        public string ProfessionalSummary { get; set; } = string.Empty;
        public List<Skill>? Skills { get; set; }
        public List<Qualification>? Education { get; set; }
        public List<Experience>? WorkExperience { get; set; }
        public List<Certification>? Certifications { get; set; }
        public List<AdditionalAccomplishment>? Accomplishments { get; set; }
        public List<Language>? Languages { get; set; }
    }
}
