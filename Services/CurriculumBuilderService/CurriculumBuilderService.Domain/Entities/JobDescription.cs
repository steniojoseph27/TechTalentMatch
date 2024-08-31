
namespace CurriculumBuilderService.Domain.Entities
{
    public class JobDescription
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Responsibilities { get; set; } = string.Empty;
        public List<string>? RequiredSkills { get; set; }
        public List<string>? PreferredSkills { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
