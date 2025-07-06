using HR_Platform.Data;
using HR_Platform.Data.Entities;
using HR_Platform.Repository.Abstractions;

namespace HR_Platform.Repository.Implementations
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
