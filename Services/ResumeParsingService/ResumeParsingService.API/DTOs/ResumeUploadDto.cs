using ResumeParsingService.Application.Models;

namespace ResumeParsingService.API.DTOs
{
    public class ResumeUploadDto
    {
        public byte[] ResumeData { get; set; }
        public FileType FileType { get; set; }
    }
}
