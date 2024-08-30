
namespace ResumeParsingService.Domain.Entities
{
    public class Education
    {
        public string InstitutionName { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty; 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FieldOfStudy { get; set; } = string.Empty;
    }
}
