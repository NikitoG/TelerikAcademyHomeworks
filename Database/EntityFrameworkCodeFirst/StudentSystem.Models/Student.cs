namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        private ICollection<Course> courses;

        private ICollection<Homework> homework;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homework = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return this.FirstName + ' ' + this.LastName; } 
        }

        [Required]
        public int Number { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homework
        {
            get { return this.homework; }
            set { this.homework = value; }
        }
    }
}
