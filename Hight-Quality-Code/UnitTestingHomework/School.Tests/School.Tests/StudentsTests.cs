namespace School.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentsTests
    {
        [TestMethod]
        public void StudentSholdNOtThrowException()
        {
            var student = new Student("Pesho Peshov");
        }

        [TestMethod]
        public void StudentShouldGenerateUniqueNumberInARange()
        {
            var student = new Student("Pesho Peshov");

            Assert.IsTrue(student.UniqueNumber >= 10000 && student.UniqueNumber <= 99999);
        }

        [TestMethod]
        public void StudentShouldReturnCorectName()
        {
            var student = new Student("Pesho Peshov");

            Assert.AreEqual("Pesho Peshov", student.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentShouldThrowExceptionWhenNameIsEmptyOrNull()
        {
            var student = new Student(null);
        }

        [TestMethod]
        public void StudentShouldGenerateUniqueNumbers()
        {
            var numbers = new List<int>();
            var areNumbersUnique = true;
            for (int i = 0; i < 100; i++)
            {
                var student = new Student("Pesho Peshov");

                if (numbers.Contains(student.UniqueNumber))
                {
                    areNumbersUnique = false;
                    break;
                }
            }

            Assert.IsTrue(areNumbersUnique);
        }
    }
}
