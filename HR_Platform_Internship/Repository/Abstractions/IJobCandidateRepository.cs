using HR_Platform_Internship.Data.Entities;
using HR_Platform_Internship.Dto;

namespace HR_Platform_Internship.Repository.Abstractions
{
    public interface IJobCandidateRepository : IRepository<JobCandidate, Guid>
    {
        Task<JobCandidate?> GetByFirstName(string firstName);

        Task<JobCandidate> GetWithSkills(Guid jobCandidateId);
        Task<JobCandidate> GetBySearch(JobCandidateSearchDto jobCandidateSearchDto);
    }
}
