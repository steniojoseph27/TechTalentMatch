
using ResumeParsingService.Domain.Entities;

namespace ResumeParsingService.Application.Models
{
    public class Resume
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public List<WorkExperience>? WorkExperience { get; set; }
        public List<Education>? Education { get; set; }
        public List<string>? Skills { get; set; }
    }
}
