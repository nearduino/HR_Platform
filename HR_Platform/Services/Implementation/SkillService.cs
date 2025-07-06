using AutoMapper;
using HR_Platform.Data.Entities;
using HR_Platform.Dto;
using HR_Platform.Repository.Abstractions;
using HR_Platform.Services.Abstractions;

namespace HR_Platform.Services.Implementation
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkills()
        {
            List<SkillDto> skillDtos = new();
            var skills = await _skillRepository.GetAll();
            foreach (var skill in skills)
            {
                var skillDto = _mapper.Map<SkillDto>(skill);
                skillDtos.Add(skillDto);
            }
            return skillDtos;
        }

        public async Task AddSkill(SkillDto skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto);
            await _skillRepository.Add(skill);
            await _skillRepository.Complete();
        }

        public async Task DeleteSkill(Guid id)
        {
            await _skillRepository.Delete(id);
            await _skillRepository.Complete();
        }
    }
}
