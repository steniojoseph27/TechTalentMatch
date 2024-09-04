
namespace CurriculumBuilderService.Domain.Entities
{
    public class Curriculum
    {
        public int Id { get; set; }
        public string ProfessionalHeader { get; set; } = string.Empty;
        public string ProfessionalSummary { get; set; } = string.Empty;
        public List<string>? Education { get; set; }
        public List<string>? WorkExperience { get; set; }
        public List<string>? Skills { get; set; }
        public List<string>? Certifications { get; set; }
        public List<string>? AdditionalAccomplishments { get; set; }
        public List<string>? Languages { get; set; }
    }
}
