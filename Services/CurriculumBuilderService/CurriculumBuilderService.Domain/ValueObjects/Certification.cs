
namespace CurriculumBuilderService.Domain.ValueObjects
{
    public class Certification
    {
        public int Id
        public string Name { get; set; } = string.Empty;
        public string IssuingOrganization { get; set; } = string.Empty;
        public DateTime DateObtained { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
