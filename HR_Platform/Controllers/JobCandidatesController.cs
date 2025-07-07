using AutoMapper;
using HR_Platform.Data;
using HR_Platform.Data.Entities;
using HR_Platform.Dto;
using HR_Platform.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidatesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobCandidateService _jobCandidateService;

        public JobCandidatesController(IMapper mapper, IJobCandidateService jobCandidateService)
        {
            _mapper = mapper;
            _jobCandidateService = jobCandidateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobCandidate>>> GetJobCandidates()
        {
            List<JobCandidate> jobCandidates = new List<JobCandidate>();
            var jobCandidateDtos = await _jobCandidateService.GetAllJobCandidates();
            foreach (var jobCandidateDto in jobCandidateDtos)
            {
                var jobCandidate = _mapper.Map<JobCandidate>(jobCandidateDto);
                jobCandidates.Add(jobCandidate);
            }
            return jobCandidates;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewJobCandidate(JobCandidateDto jobCandidateDto)
        {
            await _jobCandidateService.AddJobCandidate(jobCandidateDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobCandidateSkill(JobCandidateSkillDto jobCandidateSkillDto)
        {
            await _jobCandidateService.UpdateJobCandidatesSkill(jobCandidateSkillDto);
            return Ok();
        }

        [HttpPut("delete-job-candidate-skill")]
        public async Task<IActionResult> DeleteJobCandidateSkill(JobCandidateSkillDto jobCandidateSkillDto)
        {
            await _jobCandidateService.DeleteJobCandidatesSkill(jobCandidateSkillDto);
            return Ok();
        }

        [HttpDelete("{candidateId:guid}")]
        public async Task<IActionResult> DeleteJobCandidate(Guid candidateId)
        {
            await _jobCandidateService.DeleteJobCandidate(candidateId);
            return Ok();
        }

        [HttpGet("get-by-search")]
        public async Task<IActionResult> GetJobCandidate([FromQuery] JobCandidateSearchDto jobCandidateSearchDto)
        {
            var response = await _jobCandidateService.GetJobCandidateBySearch(jobCandidateSearchDto);
            return Ok(response);
        }
    }
}
