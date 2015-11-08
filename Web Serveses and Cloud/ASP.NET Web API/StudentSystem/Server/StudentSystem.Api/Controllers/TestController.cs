namespace StudentSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Api.Models.Students;
    using StudentSystem.Data;
    using StudentSystem.Models;

    public class TestController : ApiController
    {
        private readonly IRepository<Test> tests;
        private readonly IRepository<User> users;


        public TestController(IRepository<Test> testsRepo, IRepository<User> usersRepo)
        {
            this.tests = testsRepo;
            this.users = usersRepo;
        }

        public IHttpActionResult Get()
        {
            var result = this.tests
                .All()
                .Select(TestDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(TestDetailsResponseModel model)
        {
            var currentUser = this.users
                .All()
                .FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var newTest = new Test
            {
                CourseId = model.CourseId
            };

            this.tests.Add(newTest);
            this.tests.SaveChanges();

            return this.Ok(newTest.Id);
        }
    }
}
