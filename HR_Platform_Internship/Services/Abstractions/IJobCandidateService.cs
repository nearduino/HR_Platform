using HR_Platform_Internship.Data.Entities;
using HR_Platform_Internship.Dto;

namespace HR_Platform_Internship.Services.Abstractions
{
    public interface IJobCandidateService
    {
        Task AddJobCandidate(JobCandidateDto jobCandidateDto);
        Task UpdateJobCandidatesSkill(JobCandidateSkillDto jobCandidateSkillDto);
        Task DeleteJobCandidatesSkill(JobCandidateSkillDto jobCandidateSkillDto);
        Task DeleteJobCandidate(Guid candidateId);
        Task<JobCandidateSearchResponseDto> GetJobCandidateBySearch(JobCandidateSearchDto jobCandidateSearchDto);
    }
}
