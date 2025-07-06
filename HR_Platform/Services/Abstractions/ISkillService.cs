using HR_Platform.Data.Entities;
using HR_Platform.Dto;

namespace HR_Platform.Services.Abstractions
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDto>> GetAllSkills();
        Task AddSkill(SkillDto skillDto);
        Task DeleteSkill(Guid id);
    }
}
