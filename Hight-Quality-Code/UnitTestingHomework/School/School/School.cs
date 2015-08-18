namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private string name;
        private ICollection<Student> students;
        private ICollection<Course> courses;

        public School(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
            this.courses = new List<Course>();
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
                    throw new ArgumentOutOfRangeException("School name cannot be null or white space!");
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

        public ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentOutOfRangeException("Student cannot be null!");
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

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentOutOfRangeException("Course cannot be null!");
            }

            if (this.courses.Contains(course))
            {
                throw new InvalidOperationException("The course has already been added!");
            }

            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentOutOfRangeException("Course cannot be null!");
            }

            if (!this.courses.Contains(course))
            {
                throw new InvalidOperationException("There is not a such a course in this course!");
            }

            this.courses.Remove(course);
        }
    }
}
