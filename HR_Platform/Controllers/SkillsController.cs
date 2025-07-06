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
    public class SkillsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISkillService _skillService;

        public SkillsController(IMapper mapper, ISkillService skillService)
        {
            _mapper = mapper;
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetAllSkills()
        {
            List<Skill> skills = new List<Skill>();
            var skillDtos = await _skillService.GetAllSkills();
            foreach (var skillDto in skillDtos)
            {
                var skill = _mapper.Map<Skill>(skillDto);
                skills.Add(skill);
            }
            return skills;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewSkill(SkillDto skillDto)
        {
            await _skillService.AddSkill(skillDto);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            await _skillService.DeleteSkill(id);
            return Ok();
        }
    }
}
