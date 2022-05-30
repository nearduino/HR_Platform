using HR_Platform_Internship.Dto;

namespace HR_Platform_Internship.Services.Abstractions
{
    public interface ISkillService
    {
        Task AddSkill(SkillDto skillDto);
    }
}
