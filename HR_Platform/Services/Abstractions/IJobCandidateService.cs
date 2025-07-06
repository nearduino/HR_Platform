using HR_Platform.Data.Entities;
using HR_Platform.Dto;

namespace HR_Platform.Services.Abstractions
{
    public interface IJobCandidateService
    {
        Task<IEnumerable<JobCandidateDto>> GetAllJobCandidates();
        Task AddJobCandidate(JobCandidateDto jobCandidateDto);
        Task UpdateJobCandidatesSkill(JobCandidateSkillDto jobCandidateSkillDto);
        Task DeleteJobCandidatesSkill(JobCandidateSkillDto jobCandidateSkillDto);
        Task DeleteJobCandidate(Guid candidateId);
        Task<JobCandidateSearchResponseDto?> GetJobCandidateBySearch(JobCandidateSearchDto jobCandidateSearchDto);
    }
}
