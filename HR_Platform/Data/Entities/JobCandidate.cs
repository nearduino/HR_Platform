﻿namespace HR_Platform.Data.Entities
{
    public class JobCandidate
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public ICollection<JobCandidateSkill>? Skills { get; set; }
    }
}
