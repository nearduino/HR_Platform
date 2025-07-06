using HR_Platform.Data.Entities;

namespace HR_Platform.Dto
{
    public class JobCandidateDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public List<SkillDto>? Skills { get; set; }

    }
}
