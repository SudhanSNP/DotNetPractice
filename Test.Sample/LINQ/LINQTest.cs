using NUnit.Framework;
using System.Collections;
using Test.Sample.Enumarators;

namespace Test.Sample.LINQ
{
    [TestFixture]
    public class LINQTest
    {
        [Test]
        public void LINQQuery()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee() { Name = "Sudhan", Location = "Chennai", Role = "QA"},
                new Employee() { Name = "Sankar", Location = "Bangalore", Role = "Dev"},
                new Employee() { Name = "Sam", Location = "Bangalore", Role = "Dev"},
                new Employee() { Name = "Raghu", Location = "Chennai", Role = "Manager"},
            };

            var locations = from emp in employees 
                            select emp.Location;

            var altLocation = employees.Select(emp => emp.Location);

            var chennaiEmp = from emp in employees 
                             where emp.Location == "Chennai" select emp.Name;

            var altChennaiEmp = employees.Where(emp => emp.Location == "Chennai").Select(emp => emp.Name);

            Assert.AreEqual(locations, altLocation);
            Assert.AreEqual(chennaiEmp, altChennaiEmp);
        }
    }

    

    
}
