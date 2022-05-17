using NUnit.Framework;

namespace Test.Sample.Enumarators
{
    [TestFixture]
    public class EnumeratorTest
    {
        [Test]
        public void CustomEnumeratorTest()
        {
            Organisation emps = new Organisation();
            emps.Add(new Employee() { Name = "Sudhan", Location = "Chennai", Role = "QA" });
            emps.Add(new Employee() { Name = "Sam", Location = "Bangalore", Role = "Dev" });
            emps[1] = new Employee() { Name = "Raghu", Location = "Chennai", Role = "Manager" };

            for (int i = 0; i < emps.Count; i++)
            {
                // accessing the indexing of Organisation class
                Console.WriteLine(emps[i].Name);
            }
            // accessing the overloaded indexing of Organisation class
            Console.WriteLine(emps["Sudhan"].Role);

            foreach (Employee emp in emps)
            {
                Console.WriteLine("Name: {0} Role: {1}", emp.Name, emp.Role);
            }
        }
    }
}
