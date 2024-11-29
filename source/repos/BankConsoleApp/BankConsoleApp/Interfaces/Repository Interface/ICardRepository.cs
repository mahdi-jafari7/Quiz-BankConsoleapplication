using BankConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Interfaces.Repository_Interface
{
    public interface ICardRepository
    {
        bool login (string cardnumber, string password);

        void Bardasht(string idcart, float amount);
        void Variz(string idcart, float amount);

        Card GetById(int id);

        float Mojodi(int id);

        Card GetByCardNumber(string cardnumber);


    }
}
