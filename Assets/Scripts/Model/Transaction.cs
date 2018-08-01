namespace Model
{
    public class Transaction: Hashing
    {
        
        public double Count { get; set; }
        public int Debtor { get; set; }
        public string About { get; set; }

        public Transaction(double count, int debtor, string about)
        {
            Debtor = debtor;
            About = about;
            Count = -count;
        }

        public Transaction()
        {
        }

        public string Hash
        {
            get { return string.Format("Transaction{0}-{1}-{2}", Count, About, Debtor); }
        }
    }
}