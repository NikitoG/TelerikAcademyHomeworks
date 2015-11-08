namespace StudentSystem.Api.Models.Students
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using StudentSystem.Models;

    public class StudentDetailsResponseModel
    {
        public static Expression<Func<Student, StudentDetailsResponseModel>> FromModel
        {
            get
            {
                return st => new StudentDetailsResponseModel
                {
                    Id = st.StudentIdentification,
                    FirstName = st.FirstName,
                    LastName = st.LastName,
                    Level = st.Level
                };
            }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Level { get; set; }
    }
}