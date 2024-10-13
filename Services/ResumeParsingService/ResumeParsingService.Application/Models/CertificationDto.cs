namespace ResumeParsingService.Application.DTOs
{
    public class CertificationDto
    {
        public string Title { get; set; } = string.Empty;
        public string IssuingOrganization { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
