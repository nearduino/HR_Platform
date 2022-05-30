using AutoMapper;
using HR_Platform_Internship.Data.Entities;
using HR_Platform_Internship.Dto;
using HR_Platform_Internship.Repository.Abstractions;
using HR_Platform_Internship.Services.Abstractions;

namespace HR_Platform_Internship.Services.Implementation
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

        public async Task AddSkill(SkillDto skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto);
            await _skillRepository.Add(skill);
            await _skillRepository.Complete();
        }
    }
}
