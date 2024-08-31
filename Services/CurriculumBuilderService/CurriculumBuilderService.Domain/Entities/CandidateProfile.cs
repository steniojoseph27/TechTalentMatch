
namespace CurriculumBuilderService.Domain.Entities
{
    public class CandidateProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string>? Skills { get; set; }
        public string Education { get; set; } = string.Empty;
        public string WorkExperience { get; set; } = string.Empty;
        public List<string>? Certifications { get; set; }
        public List<string>? Accomplishments { get; set; }
        public string Language { get; set; } = string.Empty;
    }
}
