using BankConsoleApp.DbContext;
using BankConsoleApp.Entities;
using BankConsoleApp.Interfaces.Repository_Interface;
using BankConsoleApp.Interfaces.Service_Interface;
using BankConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Services
{
    public class CardService : ICardService
    {
        ICardRepository _cardRepository;
        BankDbContext _db;
        public CardService(BankDbContext db)
        {
            _db = db;
            _cardRepository = new CardRepository(db);
        }


        public void Bardasht(string sourseid, float amount)
        {
            _cardRepository.Bardasht(sourseid, amount);
        }


        public void Variz(string idcart, float amount)
        {
            _cardRepository.Variz(idcart, amount);
        }

        public Card GetById(int id)
        {
            return _cardRepository.GetById(id);
        }

        public bool login(string cardnumber, string password)
        {
            var user = _cardRepository.GetByCardNumber(cardnumber);

            if (!string.IsNullOrEmpty(user.CardNumber) && user.CardNumber.Length == 16 && user.IsActive)
            {
                return _cardRepository.login(user.CardNumber, password);
            }
            else { return false; }
        }
        public float Mojodi(int id)
        {
            var user = GetById(id);
            if (user.IsActive && user is not null)
            {
                return _cardRepository.Mojodi(user.Id);
            }
            throw new InvalidOperationException("User not found or not active.");
        }

        public Card GetByCardNumber(string cardnumber)
        {
            return _cardRepository.GetByCardNumber(cardnumber);

        }


    }
}
