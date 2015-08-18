namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void SchoolShouldNotThrowException()
        {
            var school = new School("Telerik Academy");
        }

        [TestMethod]
        public void SchoolShouldReturnCorectName()
        {
            var school = new School("Telerik Academy");

            Assert.AreEqual("Telerik Academy", school.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SchoolShouldThrowExceptionWhenNameIsEmptyOrNull()
        {
            var school = new School(null);
        }

        [TestMethod]
        public void SchoolShouldAddStudentAndNotToThrow()
        {
            var school = new School("Telerik Academy");

            for (int i = 0; i < 10; i++)
            {
                var student = new Student("Pesho #" + i);
                school.AddStudent(student);
            }

            Assert.IsTrue(school.Students.Count == 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenAddingExistingStudent()
        {
            var school = new School("Telerik Academy");

            var student = new Student("Pesho Peshov");

            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SchoolShouldThrowExceptionWhenAddStudentNull()
        {
            var school = new School("Telerik Academy");

            school.AddStudent(null);
        }

        [TestMethod]
        public void SchoolShouldRemoveStudentWhenExisting()
        {
            var school = new School("Telerik Academy");
            var student = new Student("Pesho Peshov");

            school.AddStudent(student);
            school.RemoveStudent(student);

            Assert.IsTrue(school.Students.Count == 0 && !school.Students.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenRemoveUnexistingStudent()
        {
            var school = new School("Telerik Academy");

            var student = new Student("Pesho Peshov");

            school.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SchoolShouldThrowExceptionWhenRemoveStudentNull()
        {
            var school = new School("Telerik Academy");

            school.RemoveStudent(null);
        }

        public void SchoolShouldAddCourseAndNotToThrow()
        {
            var school = new School("Telerik Academy");

            for (int i = 0; i < 10; i++)
            {
                var course = new Course("C sharp #" + i);
                school.AddCourse(course);
            }

            Assert.IsTrue(school.Courses.Count == 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenAddingExistingCourse()
        {
            var school = new School("Telerik Academy");

            var course = new Course("C#");

            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SchoolShouldThrowExceptionWhenAddCourseNull()
        {
            var school = new School("Telerik Academy");

            school.AddCourse(null);
        }

        [TestMethod]
        public void SchoolShouldRemoveCourseWhenExisting()
        {
            var school = new School("Telerik Academy");
            var course = new Course("C# OOP");

            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.IsTrue(school.Courses.Count == 0 && !school.Courses.Contains(course));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenRemoveUnexistingCourse()
        {
            var school = new School("Telerik Academy");

            var course = new Student("C# part I");

            school.RemoveStudent(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SchoolShouldThrowExceptionWhenRemoveCourseNull()
        {
            var school = new School("Telerik Academy");

            school.RemoveCourse(null);
        }
    }
}
