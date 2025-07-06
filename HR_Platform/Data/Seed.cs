using HR_Platform.Data.Entities;

namespace HR_Platform.Data
{
    public static class Seed
    {
        public static void SeedData(DataContext context)
        {
            Skill javaProgrammming = null;
            Skill cSharpProgramming = null;
            Skill dbDesign = null;
            Skill englishLanguage = null;
            Skill germanLanguage = null;


            if (!context.Skills.Any())
            {
                javaProgrammming = new Skill()
                {
                    Id = Guid.NewGuid(),
                    Name = "Java programming"
                };

                cSharpProgramming = new Skill()
                {
                    Id = Guid.NewGuid(),
                    Name = "C# programming"
                };

                dbDesign = new Skill()
                {
                    Id = Guid.NewGuid(),
                    Name = "Database design"
                };

                englishLanguage = new Skill()
                {
                    Id = Guid.NewGuid(),
                    Name = "English language"
                };

                germanLanguage = new Skill()
                {
                    Id = Guid.NewGuid(),
                    Name = "German language"
                };

                var skills = new List<Skill>()
                {
                    cSharpProgramming, javaProgrammming,
                    englishLanguage, germanLanguage, 
                    dbDesign
                };

                context.Skills.AddRange(skills);
                context.SaveChanges();
            }

            if (!context.JobCandidates.Any())
            {
                var firstCandidate = new JobCandidate()
                {
                    Id = Guid.NewGuid(),
                    Email = "marko.markovic@email.com",
                    ContactNumber = "28823823",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    FirstName = "Marko",
                    LastName = "Markovic",
                    Skills = new List<JobCandidateSkill>()
                };

                var secondCandidate = new JobCandidate()
                {
                    Id = Guid.NewGuid(),
                    Email = "jovan.jovanovic@email.com",
                    ContactNumber = "5444",
                    DateOfBirth = new DateTime(2000, 2, 2),
                    FirstName = "Jovan",
                    LastName = "Jovanovic",
                    Skills = new List<JobCandidateSkill>()
                };

                firstCandidate.Skills.Add(new JobCandidateSkill() { JobCandidateId = firstCandidate.Id, SkillId = cSharpProgramming.Id });
                firstCandidate.Skills.Add(new JobCandidateSkill() { JobCandidateId = firstCandidate.Id, SkillId = dbDesign.Id });
                firstCandidate.Skills.Add(new JobCandidateSkill() { JobCandidateId = firstCandidate.Id, SkillId = englishLanguage.Id });

                secondCandidate.Skills.Add(new JobCandidateSkill() { JobCandidateId = secondCandidate.Id, SkillId = javaProgrammming.Id });
                secondCandidate.Skills.Add(new JobCandidateSkill() { JobCandidateId = secondCandidate.Id, SkillId = dbDesign.Id });
                secondCandidate.Skills.Add(new JobCandidateSkill() { JobCandidateId = secondCandidate.Id, SkillId = germanLanguage.Id });

                context.JobCandidates.AddRange(new List<JobCandidate>()
                {
                    firstCandidate, secondCandidate
                });

                context.SaveChanges();
            }
        }
    }
}
