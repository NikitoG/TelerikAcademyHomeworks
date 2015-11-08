namespace StudentSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Api.Models.Students;
    using StudentSystem.Data;
    using StudentSystem.Models;

    public class CourseController : ApiController
    {
        private readonly IRepository<Course> courses;
        private readonly IRepository<User> users;


        public CourseController(IRepository<Course> coursesRepo, IRepository<User> usersRepo)
        {
            this.courses = coursesRepo;
            this.users = usersRepo;
        }

        public IHttpActionResult Get()
        {
            var result = this.courses
                .All()
                .Select(CourseDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(CourseDetailsResponseModel model)
        {
            var currentUser = this.users
                .All()
                .FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var newCourse = new Course
            {
                Name = model.Name,
                Description = model.Description
            };

            this.courses.Add(newCourse);
            this.courses.SaveChanges();

            return this.Ok(newCourse.Id);
        }
    }
}
