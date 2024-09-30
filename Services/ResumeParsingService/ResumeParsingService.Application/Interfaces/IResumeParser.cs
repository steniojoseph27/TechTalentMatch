using ResumeParsingService.Application.Models;

namespace ResumeParsingService.Application.Interfaces
{
    public interface IResumeParser
    {
        ParsedResumeDto ParseResume(byte[] resumeData, FileType fileType);
    }
}
