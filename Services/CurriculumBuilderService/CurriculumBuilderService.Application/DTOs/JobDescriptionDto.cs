using CurriculumBuilderService.Domain.ValueObjects;

namespace CurriculumBuilderService.Application.DTOs
{
    public class JobDescriptionDto
    {
        public string Title { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public List<Responsibility>? Responsibilities { get; set; } = new List<Responsibility>();
        public List<Skill>? RequiredSkills { get; set; } = new List<Skill>();
        public List<Skill>? PreferredSkills { get; set; } = new List<Skill>();
        public List<Qualification>? Qualifications { get; set; } = new List<Qualification>();
    }
}
