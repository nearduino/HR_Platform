using AutoMapper;
using HR_Platform_Internship.Data.Entities;
using HR_Platform_Internship.Services.Implementation;

namespace HR_Platform_Tests
{
    public class JobCnadidateTests
    {
        private readonly IMapper _mapper;

        [Fact]
        public async void AddJobCandidate_TestAsync()
        {
            JobCandidateService jcs = new JobCandidateService();
            JobCandidate jc = new JobCandidate()
            {
                Id = Guid.NewGuid(),
                FirstName = "David",
                LastName = "Bosnjak",
                DateOfBirth = DateTime.Now,
                ContactNumber = "063723908",
                Email = "programmer@mail.com",
            };

            bool exceptionThrown = false;
            try
            {
                jcs.AddJobCandidate();
            }
            catch(Exception)
            { 
            }
        }
    }
}