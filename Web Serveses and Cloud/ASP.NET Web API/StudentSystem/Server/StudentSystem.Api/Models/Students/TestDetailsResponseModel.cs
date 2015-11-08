namespace StudentSystem.Api.Models.Students
{
    using System;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class TestDetailsResponseModel
    {
        public static Expression<Func<Test, TestDetailsResponseModel>> FromModel
        {
            get
            {
                return t => new TestDetailsResponseModel
                {
                    Id = t.Id,
                    CourseId = t.CourseId
                };
            }
        }

        public int Id { get; set; }

        public virtual Guid CourseId { get; set; }
    }
}