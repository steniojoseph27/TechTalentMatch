﻿
namespace CurriculumBuilderService.Domain.ValueObjects
{
    public class AdditionalAccomplishment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
