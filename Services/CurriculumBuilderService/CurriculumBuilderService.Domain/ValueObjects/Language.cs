
namespace CurriculumBuilderService.Domain.ValueObjects
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProficiencyLevel { get; set; } = string.Empty;
    }
}
