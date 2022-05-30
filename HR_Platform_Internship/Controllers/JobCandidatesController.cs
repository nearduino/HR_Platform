using HR_Platform_Internship.Data.Entities;
using HR_Platform_Internship.Dto;
using HR_Platform_Internship.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Platform_Internship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidatesController : ControllerBase
    {
        private readonly IJobCandidateService _jobCandidateService;

        public JobCandidatesController(IJobCandidateService jobCandidateService)
        {
            _jobCandidateService = jobCandidateService;
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

        [HttpDelete]
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
