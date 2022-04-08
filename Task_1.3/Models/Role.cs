namespace Task_1._3.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
        public Role()
        {
            Accounts = new List<Account>();
        }
    }
}
