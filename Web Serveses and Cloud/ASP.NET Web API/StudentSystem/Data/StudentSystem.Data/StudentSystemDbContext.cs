namespace StudentSystem.Data
{

    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using StudentSystem.Models;

    public class StudentSystemDbContext : IdentityDbContext<User>, IStudentSystemDbContext
    {
        public StudentSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<Test> Tests { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public static StudentSystemDbContext Create()
        {
            return new StudentSystemDbContext();
        }
    }
}
