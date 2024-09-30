namespace ResumeParsingService.Application.Models
{
    public class WorkExperienceDto
    {
        public string JobTitle { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Responsibilities { get; set; } = string.Empty;
    }
}