using ResumeParsingService.Application.Interfaces;
using ResumeParsingService.Application.Models;
using ResumeParsingService.Application.Parsers;

namespace ResumeParsingService.Application.Services
{
    public class ResumeParserService : IResumeParser
    {
        private readonly IPdfResumeParser _pdfResumeParser;
        private readonly IDocxResumeParser _docxResumeParser;
        private readonly ILinkedInProfileParser _linkedInProfileParser;

        public ResumeParserService(IPdfResumeParser pdfResumeParser, IDocxResumeParser docxResumeParser, ILinkedInProfileParser linkedInProfileParser)
        {
            _pdfResumeParser = pdfResumeParser;
            _docxResumeParser = docxResumeParser;
            _linkedInProfileParser = linkedInProfileParser;
        }
        
        public ParsedResumeDto ParseResume(Stream resumeStream, FileType fileType)
        {
            switch (fileType.ToLower())
            {
                case ".pdf":
                    return _pdfResumeParser.Parse(resumeStream);
                case ".docx":
                    return _docxResumeParser.Parse(resumeStream);
                default:
                    throw new NotSupportedException($"Unsupported file type: {fileType}");
            }
        }

        public async Task<ResumeDto> ParseLinkedInProfileAsync(string accessToken)
        {
            return await _linkedInProfileParser.ParseFromLinkedInProfileAsync(accessToken);
        }
    }
}
