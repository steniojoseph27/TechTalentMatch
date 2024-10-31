using ResumeParsingService.Application.DTOs;
using System.Threading.Tasks;

namespace ResumeParsingService.Application.Parsers
{
    public interface ILinkedInProfileParser
    {
        Task<ResumeDto> ParseFromLinkedInProfileAsync(string accessToken);
    }
}
