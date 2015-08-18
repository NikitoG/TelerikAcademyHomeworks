namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private List<string> students;

        protected Course(string name)
        {
            this.Name = name;
            this.students = new List<string>();
        }

        protected Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
        }

        protected Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.IsNull(value, "Name of Course");
                Validator.ValidateName(value, "Name of course");
                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                Validator.IsNull(value, "Teacher name");
                Validator.ValidateName(value, "Teacher name");
                this.teacherName = value;
            }
        }

        public ICollection<string> Students
        {
            get
            {
                return new List<string>(this.students);
            }

            set
            {
                this.AddStudent(value.ToArray());
            }
        }

        public void AddStudent(params string[] students)
        {
            if (students == null)
            {
                throw new NullReferenceException("Students can not be null!");
            }

            foreach (var student in students)
            {
                Validator.IsNull(student, "Student name");
                Validator.ValidateName(student, "Student name");
                this.students.Add(student);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
