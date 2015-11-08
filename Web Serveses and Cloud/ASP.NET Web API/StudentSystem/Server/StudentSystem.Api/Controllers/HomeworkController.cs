namespace StudentSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Api.Models.Students;
    using StudentSystem.Data;
    using StudentSystem.Models;

    public class HomeworkController : ApiController
    {
        private readonly IRepository<Homework> homework;
        private readonly IRepository<User> users;


        public HomeworkController(IRepository<Homework> homeworkRepo, IRepository<User> usersRepo)
        {
            this.homework = homeworkRepo;
            this.users = usersRepo;
        }

        public IHttpActionResult Get()
        {
            var result = this.homework
                .All()
                .Select(HomeworkDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(HomeworkDetailsResponseModel model)
        {
            var currentUser = this.users
                .All()
                .FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var newHomework = new Homework
            {
                FileUrl = model.FileUrl,
                StudentIdentification = model.StudentIdentification,
                CourseId = model.CourseId,
                TimeSent = DateTime.Now
            };

            this.homework.Add(newHomework);
            this.homework.SaveChanges();

            return this.Ok(newHomework.Id);
        }
    }
}
