using CurriculumBuilderService.Domain.Entities;

namespace CurriculumBuilderService.Domain.ValueObjects
{
    public class Experience
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Responsibilities { get; set; } = string.Empty;
        public int CandidateProfileId { get; set; }
        public CandidateProfile? CandidateProfile { get; set; }
    }
}
