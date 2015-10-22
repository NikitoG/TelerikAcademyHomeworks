namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        private ICollection<Student> students;

        private ICollection<Homework> homework;

        public Course()
        {
            this.Id = Guid.NewGuid();
            this.Materials = new List<string>();
            this.students = new HashSet<Student>();
            this.homework = new HashSet<Homework>();
        }

        public Guid Id { get; set; }

        [Required]
        [Column("Corse Name")]
        public string Name { get; set; }

        [Column("Corse Description")]
        public string Description { get; set; }

        public ICollection<string> Materials { get; set; }

        public virtual ICollection<Student> Students 
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homework
        {
            get { return this.homework; }
            set { this.homework = value; }
        }
    }
}
