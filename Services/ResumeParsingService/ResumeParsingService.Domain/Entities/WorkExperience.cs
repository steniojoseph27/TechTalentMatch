
namespace ResumeParsingService.Domain.Entities
{
    public class WorkExperience
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Responsibilities { get; set; } = string.Empty;
    }
}
