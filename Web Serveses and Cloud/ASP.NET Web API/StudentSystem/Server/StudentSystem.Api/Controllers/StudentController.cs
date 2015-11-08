namespace StudentSystem.Api.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Api.Models.Students;
    using StudentSystem.Models;

    public class StudentController : ApiController
    {
        private readonly IRepository<Student> students;
        private readonly IRepository<User> users;


        public StudentController(IRepository<Student> studentsRepo, IRepository<User> usersRepo)
        {
            this.students = studentsRepo;
            this.users = usersRepo;
        }

        public IHttpActionResult Get()
        {
            var result = this.students
                .All()
                .OrderByDescending(st => st.Level)
                .Take(10)
                .Select(StudentDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.students
                .All()
                .Where(st => st.StudentIdentification == id)
                .Select(StudentDetailsResponseModel.FromModel)
                .FirstOrDefault();

            if(result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Route("api/students/all")]
        public IHttpActionResult Get(int page, int pageSize = 10)
        {
            var result = this.students
                .All()
                .OrderByDescending(st => st.Level)
                .Skip((page - 1) * pageSize)
                .Take(10)
                .Select(StudentDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(SaveStudentRequestModel model)
        {
            var currentUser = this.users
                .All()
                .FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var newStudent = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Level = model.Level
            };

            this.students.Add(newStudent);
            this.students.SaveChanges();

            return this.Ok(newStudent.StudentIdentification);
        }
    }
}
