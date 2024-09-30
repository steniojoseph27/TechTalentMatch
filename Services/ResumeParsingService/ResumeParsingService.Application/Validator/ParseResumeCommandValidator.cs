using FluentValidation;
using ResumeParsingService.Application.Commands;

namespace ResumeParsingService.Application.Validator
{
    public class ParseResumeCommandValidator : AbstractValidator<ParseResumeCommand>
    {
        public ParseResumeCommandValidator()
        {
            RuleFor(x => x.ResumeData).NotEmpty().WithMessage("Resume data must not be empty.");
            RuleFor(x => x.FileType).IsInEnum().WithMessage("Invalid file type.");
        }
    }
}
