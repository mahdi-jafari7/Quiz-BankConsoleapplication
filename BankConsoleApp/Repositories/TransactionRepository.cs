using BankConsoleApp.DbContext;
using BankConsoleApp.Entities;
using BankConsoleApp.Interfaces.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        BankDbContext _bankdb;
        public TransactionRepository(BankDbContext bankdb)
        {
            _bankdb = bankdb;
        }

        public void Add(Transaction transaction)
        {
            _bankdb.Add(transaction);
            _bankdb.SaveChanges();
        }

        public List<Transaction> GetById(int uesrid)
        {
            return _bankdb.Transactions.Where(t => t.forCardId == uesrid).ToList();
        }

        
    }
}
