namespace StudentSystem.Api.Models.Students
{
    using System;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class CourseDetailsResponseModel
    {
        public static Expression<Func<Course, CourseDetailsResponseModel>> FromModel
        {
            get
            {
                return c => new CourseDetailsResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                };
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}