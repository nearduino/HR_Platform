namespace HR_Platform.Data.Entities
{
    public class JobCandidateSkill
    {
        public Guid JobCandidateId { get; set; }
        public JobCandidate? JobCandidate { get; set; }
        public Guid SkillId { get; set; }
        public Skill? Skill { get; set; }
    }
}
