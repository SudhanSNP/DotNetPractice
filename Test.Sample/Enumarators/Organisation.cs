using System.Collections;

namespace Test.Sample.Enumarators
{
    // IEnumrable class for implementing Custom collection
    public class Organisation : IEnumerable
    {
        List<Employee> Employees = new List<Employee>();
        // Indexer
        public Employee this[int index]
        {
            get
            {
                return Employees[index];
            }
            set
            {
                Employees[index] = value;
            }
        }

        // Indexer Overloading
        public Employee this[string name]
        {
            get
            {
                return Employees.Where(emp => emp.Name.Equals(name)).Select(emp => emp).FirstOrDefault();
            }
        }

        public int Count { get { return Employees.Count; } }

        public void Add(Employee emp)
        {
            Employees.Add(emp);
        }
        public IEnumerator GetEnumerator()
        {
            return new OrganisationEnumarator(this);
        }
    }
}
