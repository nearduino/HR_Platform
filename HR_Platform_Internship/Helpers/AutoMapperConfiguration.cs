using AutoMapper;
using HR_Platform_Internship.Data.Entities;
using HR_Platform_Internship.Dto;

namespace HR_Platform_Internship.Helpers
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
