using ResumeParsingService.Application.DTOs;
using System.IO;

namespace ResumeParsingService.Application.Parsers
{
    public interface IPdfResumeParser
    {
        ResumeDto Parse(Stream pdfStream);
    }
}