using HR_Platform_Internship.Dto;
using HR_Platform_Internship.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Platform_Internship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewSkill(SkillDto skillDto)
        {
            await _skillService.AddSkill(skillDto);
            return Ok();
        }
    }
}
