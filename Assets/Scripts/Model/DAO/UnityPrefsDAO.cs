using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Model.Blockchain;
using UnityEngine;

namespace Model.DAO
{
    public class UnityPrefsDAO: DAO
    {


        private const string DEBTORS_IDS = "debtors_ids";
        private const string START = "bjsbfjbfjbssbjfb313";
        private const string CURRENT = "current_block";

        public UnityPrefsDAO()
        {
            if (!PlayerPrefs.HasKey(DEBTORS_IDS))
            {
                PlayerPrefs.SetString(DEBTORS_IDS, ToXML(new List<int>()));
            }
            
            if (!PlayerPrefs.HasKey(CURRENT))
            {
                PlayerPrefs.SetString(CURRENT, START);
            }
        }


        public List<int> Debtors
        {
            get
            {
                return FromFXML<List<int>>(PlayerPrefs.GetString(DEBTORS_IDS)); 
            }
        }

        public Debtor GetDebotById(int id)
        {
            string key = "debtor" + id;
            return FromFXML<Debtor>(PlayerPrefs.GetString(key));
        }

        public List<Transaction> GetTransactionsById(int id)
        {
            List<Transaction> result = new List<Transaction>();
            var current = PlayerPrefs.GetString(CURRENT);
            while (!current.Equals(START))
            {
                var block = FromFXML<Block>(PlayerPrefs.GetString(current));
                var transaction = block.Transaction;
                if (transaction.Debtor == id)
                {
                    result.Add(transaction);

                }
                current = block.Before;
            }

            return result;
        }

        public void AddTransaction(double count, int debtor, string about, bool isPay)
        {
            if (isPay)
            {
                count *= -1;
            }
            Transaction transaction = new Transaction(count, debtor, about);
            var block = new Block(PlayerPrefs.GetString(CURRENT), transaction);
            PlayerPrefs.SetString(block.Hash, ToXML(block));
            PlayerPrefs.SetString(CURRENT, block.Hash);
        }

        public void AddDebtor(string name, string about)
        {
            var list = Debtors;
            var id = list.Count + 1;
            list.Add(id);
            PlayerPrefs.SetString(DEBTORS_IDS, ToXML(list));
            string key = "debtor" + id;
            var debtor = new Debtor(id, name, about);
            PlayerPrefs.SetString(key, ToXML(debtor));
        }


        private static string ToXML<T>(T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            var xml = "";

            using(var sww = new StringWriter())
            {
                using(XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, obj);
                    xml = sww.ToString(); 
                }
            }

            return xml;
        }

        private static T FromFXML<T>(string xml)
        {
            T res = default(T);
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));

            using (var readerString = new StringReader(xml))
            {
                using (XmlReader reader = XmlReader.Create(readerString))
                {
                    res = (T) xsSubmit.Deserialize(reader);
                }
            }

            return res;
        }
    }
}