namespace Model
{
    public class Debtor
    {
        public Debtor()
        {
            
        }

        public Debtor(int id, string name, string about)
        {
            this.Id = id;
            this.Name = name;
            this.About = about;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }
    }
}