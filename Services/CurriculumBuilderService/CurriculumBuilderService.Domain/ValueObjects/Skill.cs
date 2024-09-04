using CurriculumBuilderService.Domain.Entities;

namespace CurriculumBuilderService.Domain.ValueObjects
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public int JobDescriptionId { get; set; }
        public JobDescription? JobDescription { get; set; }
    }
}
