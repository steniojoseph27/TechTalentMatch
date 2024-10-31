using ResumeParsingService.Application.DTOs;
using System.IO;

namespace ResumeParsingService.Application.Parsers
{
    public interface IDocxResumeParser
    {
        ResumeDto Parse(Stream docxStream);
    }
}