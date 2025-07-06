namespace HR_Platform.Data.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<JobCandidateSkill>? JobCandidates { get; set; }
    }
}
