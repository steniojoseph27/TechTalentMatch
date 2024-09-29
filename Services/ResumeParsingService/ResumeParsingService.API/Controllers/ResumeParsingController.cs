using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResumeParsingService.API.DTOs;
using ResumeParsingService.Application.Commands;

namespace ResumeParsingService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeParsingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResumeParsingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadResume([FromBody] ResumeUploadDto resumeUploadDto)
        {
            var command = new ParseResumeCommand(resumeUploadDto.ResumeData, resumeUploadDto.FileType);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
