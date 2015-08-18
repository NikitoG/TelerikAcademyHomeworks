namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CourseShouldNotThrowException()
        {
            var course = new Course("C# OOP");
        }

        [TestMethod]
        public void CourseShouldReturnCorectName()
        {
            var course = new Course("C# OOP");

            Assert.AreEqual("C# OOP", course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseShouldThrowExceptionWhenNameIsEmptyOrNull()
        {
            var course = new Course(null);
        }

        [TestMethod]
        public void CourseShouldAddStudentAndNotToThrow()
        {
            var course = new Course("C# OOP");

            for (int i = 0; i < 10; i++)
            {
                var student = new Student("Pesho #" + i);
                course.AddStudent(student);
            }

            Assert.IsTrue(course.Students.Count == 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenAddingExistingStudent()
        {
            var course = new Course("C# OOP");

            var student = new Student("Pesho Peshov");

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseShouldThrowExceptionWhenAddStudentNull()
        {
            var course = new Course("C# OOP");

            course.AddStudent(null);
        }

        [TestMethod]
        public void CourseShouldRemoveStudentWhenExisting()
        {
            var course = new Course("C# OOP");
            var student = new Student("Pesho Peshov");

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.IsTrue(course.Students.Count == 0 && !course.Students.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenRemoveUnexistingStudent()
        {
            var course = new Course("C# OOP");

            var student = new Student("Pesho Peshov");

            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseShouldThrowExceptionWhenRemoveStudentNull()
        {
            var course = new Course("C# OOP");

            course.RemoveStudent(null);
        }
    }
}