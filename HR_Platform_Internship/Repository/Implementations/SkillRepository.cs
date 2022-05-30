using HR_Platform_Internship.Data;
using HR_Platform_Internship.Data.Entities;
using HR_Platform_Internship.Repository.Abstractions;

namespace HR_Platform_Internship.Repository.Implementations
{
    public class SkillRepository : Repository<Skill, Guid>, ISkillRepository
    {
        private readonly DataContext _dataContext;

        public SkillRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}
