using NUnit.Framework;
using SchoolApp.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //-- Arrance
            Student student = new Student();
            student.FirstName = "Mauricio";
            student.LastName = "Bergallo";

            string expectedResult = "Bergallo, Mauricio";
            
            //-- Act
            string actualResult = student.FullName;
            
            //-- Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}