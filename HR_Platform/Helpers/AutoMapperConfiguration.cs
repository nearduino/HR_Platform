using AutoMapper;
using HR_Platform.Data.Entities;
using HR_Platform.Dto;

namespace HR_Platform.Helpers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<JobCandidateDto, JobCandidate>();
            CreateMap<SkillDto, Skill>();

            CreateMap<JobCandidate, JobCandidateDto>();
            CreateMap<Skill, SkillDto>();

            CreateMap<SkillDto, JobCandidateSkill>()
                .ForMember(opt => opt.SkillId, dest => dest.MapFrom(src => src.Id));

            CreateMap<JobCandidate, JobCandidateSearchResponseDto>();
        }
    }
}
