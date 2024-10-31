namespace ResumeParsingService.Application.DTOs
{
    public class ExperienceDto
    {
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string> Responsibilities { get; set; } = new();
    }
}
