using ResumeParsingService.Application.Models;

namespace ResumeParsingService.Application.Interfaces
{
    public interface IResumeParser
    {
        ParsedResumeDto ParseResume(Stream resumeStream, FileType fileType);
        Task<ResumeDto> ParseLinkedInProfileAsync(string accessToken);
    }
}
