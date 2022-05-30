using HR_Platform_Internship.Data.Entities;

namespace HR_Platform_Internship.Dto
{
    public class JobCandidateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public List<SkillDto> Skills { get; set; }

    }
}
