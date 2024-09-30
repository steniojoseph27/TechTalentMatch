using ResumeParsingService.Application.Models;

namespace ResumeParsingService.Application.Commands
{
    public class ParseResumeCommand
    {
        public byte[] ResumeData { get; set; }
        public FileType FileType { get; set; }

        public ParseResumeCommand(byte[] resumeData, FileType fileType)
        {
            ResumeData = resumeData;
            FileType = fileType;
        }
    }
}
