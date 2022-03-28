using Task_1._3.Models;

namespace Task_1._3.interfaces
{
    public interface IPerson
    {
        IEnumerable<Person> People { get; set; }
    }
}
