using BankConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Interfaces.Service_Interface
{
    public interface ICardService
    {
        public void Bardasht(string sourseid, float amount);
        public void Variz(string idcart, float amount);
        public Card GetById(int id);
        public bool login(string cardnumber, string password);
        public float Mojodi(int id);
        Card GetByCardNumber(string cardnumber);

    }
}
