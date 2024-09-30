
namespace ResumeParsingService.Application.Models
{
    public class ParsedResumeDto
    {
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public List<WorkExperienceDto>? WorkExperience { get; set; }
        public List<EducationDto>? Education { get; set; }
        public List<string>? Skills { get; set; }
    }
}
