using CurriculumBuilderService.Domain.Entities;

namespace CurriculumBuilderService.Domain.ValueObjects
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int JobDescriptionId { get; set; }
        public JobDescription? JobDescription { get; set; }
    }
}
