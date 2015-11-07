namespace StudentSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using StudentSystem.Models;

    public class StudentSystemDbContext : IdentityDbContext<User>
    {
        public StudentSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static StudentSystemDbContext Create()
        {
            return new StudentSystemDbContext();
        }
    }
}
