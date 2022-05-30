using AutoMapper;
using HR_Platform_Internship.Data.Entities;
using HR_Platform_Internship.Dto;
using HR_Platform_Internship.Repository.Abstractions;
using HR_Platform_Internship.Services.Abstractions;

namespace HR_Platform_Internship.Services.Implementation
{
    public class JobCandidateService : IJobCandidateService
    {
        private readonly IJobCandidateRepository _jobCandidateRepository;
        private readonly IMapper _mapper;

        public JobCandidateService()
        {
        }

        public JobCandidateService(IJobCandidateRepository jobCandidateRepository, IMapper mapper)
        {
            _jobCandidateRepository = jobCandidateRepository;
            _mapper = mapper;
        }

        public async Task AddJobCandidate(JobCandidateDto jobCandidateDto)
        {
            var jobCandidate = _mapper.Map<JobCandidate>(jobCandidateDto);

            await _jobCandidateRepository.Add(jobCandidate);
            await _jobCandidateRepository.Complete();  
        }

        public async Task DeleteJobCandidate(Guid candidateId)
        {
            await _jobCandidateRepository.Delete(candidateId);
            await _jobCandidateRepository.Complete();
        }

        public async Task DeleteJobCandidatesSkill(JobCandidateSkillDto jobCandidateSkillDto)
        {
            var jobCandidate = await _jobCandidateRepository.GetWithSkills(jobCandidateSkillDto.JobCandidateId);

            if (jobCandidate == null) return;

            var jobCandidateSkill = jobCandidate.Skills.FirstOrDefault(a => a.SkillId == jobCandidateSkillDto.SkillId);

            if (jobCandidateSkill == null) return;

            jobCandidate.Skills.Remove(jobCandidateSkill);

            await _jobCandidateRepository.Complete();
        }

        public async Task<JobCandidateSearchResponseDto> GetJobCandidateBySearch(JobCandidateSearchDto jobCandidateSearchDto)
        {
            var jobCandidate = await _jobCandidateRepository.GetBySearch(jobCandidateSearchDto);
            
            if (jobCandidate == null) return null;

            return _mapper.Map<JobCandidateSearchResponseDto>(jobCandidate);
        }

        public async Task UpdateJobCandidatesSkill(JobCandidateSkillDto jobCandidateSkillDto)
        {
            var jobCandidate = await _jobCandidateRepository.GetWithSkills(jobCandidateSkillDto.JobCandidateId);

            if (jobCandidate == null) return;

            var jobCandidateSkill = jobCandidate.Skills.FirstOrDefault(a => a.SkillId == jobCandidateSkillDto.SkillId);

            if (jobCandidateSkill != null) return;

            jobCandidate.Skills.Add(new JobCandidateSkill() { JobCandidateId = jobCandidate.Id, SkillId = jobCandidateSkillDto.SkillId });

            _jobCandidateRepository.Update(jobCandidate);
            await _jobCandidateRepository.Complete();
        }
    }
}
