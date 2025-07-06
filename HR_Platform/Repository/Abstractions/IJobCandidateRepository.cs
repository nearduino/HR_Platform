using HR_Platform.Data.Entities;
using HR_Platform.Dto;

namespace HR_Platform.Repository.Abstractions
{
    public interface IJobCandidateRepository : IRepository<JobCandidate, Guid>
    {
        Task<JobCandidate?> GetByFirstName(string firstName);

        Task<JobCandidate> GetWithSkills(Guid jobCandidateId);
        Task<JobCandidate> GetBySearch(JobCandidateSearchDto jobCandidateSearchDto);
    }
}
