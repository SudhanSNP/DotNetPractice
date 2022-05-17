using System.Collections;

namespace Test.Sample.Enumarators
{
    // Enumerator Class for iterating the Organisation (IEnumerable) class
    public class OrganisationEnumerator : IEnumerator
    {
        Organisation org;
        int CurrentIndex;
        Employee CurrentEmployee;

        public OrganisationEnumerator(Organisation org)
        {
            this.org = org;
            CurrentIndex = -1;
        }

        public Object Current
        {
            get
            {
                return CurrentEmployee;
            }
        }

        public bool MoveNext()
        {
            if (++CurrentIndex >= org.Count)
                return false;
            else
                CurrentEmployee = org[CurrentIndex];
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
