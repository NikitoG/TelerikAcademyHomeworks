namespace StudentSystem.Api.Models.Students
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class HomeworkDetailsResponseModel
    {
        public static Expression<Func<Homework, HomeworkDetailsResponseModel>> FromModel
        {
            get
            {
                return h => new HomeworkDetailsResponseModel
                {
                    Id = h.Id,
                    FileUrl = h.FileUrl,
                    StudentIdentification = h.StudentIdentification,
                    CourseId = h.CourseId
                };
            }
        }

        public int Id { get; set; }

        public string FileUrl { get; set; }

        public int StudentIdentification { get; set; }

        public Guid CourseId { get; set; }

        public DateTime TimeSent { get; set; }
    }
}