namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentInCourse = 30;

        private string name;
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Course name cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentOutOfRangeException("Student cannot be null!");
            }

            if (this.students.Count == MaxStudentInCourse)
            {
                throw new InvalidOperationException("Students in a course should be less than " + MaxStudentInCourse);
            }

            if (this.students.Contains(student))
            {
                throw new InvalidOperationException("The student has already been added!");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentOutOfRangeException("Student cannot be null!");
            }

            if (!this.students.Contains(student))
            {
                throw new InvalidOperationException("There is not a such a student in this course!");
            }

            this.students.Remove(student);
        }
    }
}
