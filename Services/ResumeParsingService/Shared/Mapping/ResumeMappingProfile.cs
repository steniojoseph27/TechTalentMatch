using System;

namespace ResumeParsingService.Shared.Mapping
{
    public class ResumeMappingProfile : Profile
    {
        public ResumeMappingProfile()
        {
            CreateMap<Resume, ParsedResumeDto>().ReverseMap();
        }
    }
}
