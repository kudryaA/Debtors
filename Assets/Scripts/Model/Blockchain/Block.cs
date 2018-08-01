namespace Model.Blockchain
{
    public class Block: Hashing
    {
        public string Before { get; set; }

        public Transaction Transaction { get; set; }

        public Block()
        {
        }

        public Block(string before, Transaction transaction)
        {
            Before = before;
            Transaction = transaction;
        }

        public string Hash
        {
            get { return string.Format("{0}-{1}", Before, Transaction.Hash); }
        }
    }
}