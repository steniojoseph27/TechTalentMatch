using CurriculumBuilderService.Domain.Entities;

namespace CurriculumBuilderService.Domain.ValueObjects
{
    public class Responsibility
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int JobDescriptionId { get; set; }
        public JobDescription? JobDescription { get; set; }
    }
}
