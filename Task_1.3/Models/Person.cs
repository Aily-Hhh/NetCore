using System;
using System.ComponentModel;

namespace Task_1._3.Models
{
    public class Person
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }
    }
}
