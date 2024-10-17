namespace ResumeParsingService.Infrastructure.Settings
{
    public class DocxResumeParserSettings
    {
        public int MaxFileSize { get; set; }
        public string[] SupportedExtensions { get; set; }
    }
}