using HR_Platform_Internship.Data;
using HR_Platform_Internship.Data.Entities;
using HR_Platform_Internship.Dto;
using HR_Platform_Internship.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HR_Platform_Internship.Repository.Implementations
{
    public class JobCandidateRepository : Repository<JobCandidate, Guid>, IJobCandidateRepository
    {
        private readonly DataContext _dataContext;
        public JobCandidateRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        public Task<JobCandidate?> GetByFirstName(string firstName)
        {
            var candidate = _dataContext.JobCandidates.FirstOrDefault(a => a.FirstName == firstName);
            return Task.FromResult(candidate);
        }

        public async Task<JobCandidate?> GetWithSkills(Guid jobCandidateId) =>
            await _dataContext.JobCandidates
                .Include(a => a.Skills)
                .FirstOrDefaultAsync(a => a.Id == jobCandidateId);

        public async Task<JobCandidate?> GetBySearch(JobCandidateSearchDto jobCandidateSearchDto) {

            if (string.IsNullOrEmpty(jobCandidateSearchDto.SkillName) && !string.IsNullOrEmpty(jobCandidateSearchDto.JobCandidateName))
            {
                return await _dataContext.JobCandidates
                    .Include(a => a.Skills)
                    .FirstOrDefaultAsync(a => a.FirstName.Equals(jobCandidateSearchDto.JobCandidateName)
                        || a.LastName.Equals(jobCandidateSearchDto.JobCandidateName));
            }
            else if (!string.IsNullOrEmpty(jobCandidateSearchDto.SkillName) && string.IsNullOrEmpty(jobCandidateSearchDto.JobCandidateName))
            {
                return await _dataContext.JobCandidates
                    .Include(a => a.Skills)
                    .FirstOrDefaultAsync(a =>
                        a.Skills.Any(a => a.Skill.Name.Equals(jobCandidateSearchDto.SkillName)));
            }
            else if (!string.IsNullOrEmpty(jobCandidateSearchDto.SkillName) && !string.IsNullOrEmpty(jobCandidateSearchDto.JobCandidateName))
            {
                return await _dataContext.JobCandidates
                    .Include(a => a.Skills)
                    .FirstOrDefaultAsync(a =>
                        (a.FirstName.Equals(jobCandidateSearchDto.JobCandidateName)
                        || a.LastName.Equals(jobCandidateSearchDto.JobCandidateName))
                        && a.Skills.Any(a => a.Skill.Name.Equals(jobCandidateSearchDto.SkillName)));
            }
            else return null;
        }
    }
}
