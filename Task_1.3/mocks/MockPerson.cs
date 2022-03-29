using Task_1._3.interfaces;
using Task_1._3.Models;

namespace Task_1._3.mocks
{
    public class MockPerson : IPerson
    {
        public List<Person> peopleList = new List<Person>{
                    new Person { Id = 1, Name = "Dana", Age = 19},
                    new Person { Id = 2, Name = "Vika", Age = 23}
                };
        public IEnumerable<Person> People 
        {
            get
            {
                return peopleList;
            }
            set
            {
                peopleList.Add(new Person());
            }
        }
    }
}
