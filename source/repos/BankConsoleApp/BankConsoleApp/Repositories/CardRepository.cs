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
    public class CardRepository : ICardRepository
    {
        BankDbContext _bankdb;
        public CardRepository(BankDbContext bankdb)
        {
            _bankdb = bankdb;
        }

        public void Bardasht(string idcart, float amount)
        {
            var user = _bankdb.Cards.FirstOrDefault(o => o.CardNumber == idcart);

            user.Balance -= amount;
            _bankdb.SaveChanges();
        }


        public void Variz(string idcart, float amount)
        {
            var user = _bankdb.Cards.FirstOrDefault(o => o.CardNumber == idcart);

            user.Balance+= amount;
            _bankdb.SaveChanges();
        }

        public Card GetById(int id)
        {
            return _bankdb.Cards.FirstOrDefault(o => o.Id == id);
        }

        public bool login(string cardnumber, string password)
        {
            return _bankdb.Cards.Any(u => u.CardNumber == cardnumber && u.Password == password);
        }

        public float Mojodi(int id)
        {
            var user =  _bankdb.Cards.FirstOrDefault(o => o.Id == id);
            return user.Balance;
        }

        public Card GetByCardNumber(string cardnumber)
        {
            return _bankdb.Cards.FirstOrDefault(o => o.CardNumber == cardnumber);
        }

    }
}
