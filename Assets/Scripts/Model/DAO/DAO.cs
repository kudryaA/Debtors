using System.Collections.Generic;

namespace Model.DAO
{
    public interface DAO
    {
        List<int> Debtors { get; }
        Debtor GetDebotById(int id);
        List<Transaction> GetTransactionsById(int id);
        void AddTransaction(double count, int debtor, string about, bool isPay);
        void AddDebtor(string name, string about);
    }
}