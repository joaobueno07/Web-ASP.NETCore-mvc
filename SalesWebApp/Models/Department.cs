namespace SalesWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }


    }
}
