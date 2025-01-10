using BankConsoleApp.DbContext;
using BankConsoleApp.Entities;
using BankConsoleApp.Interfaces.Service_Interface;
using BankConsoleApp.Services;

BankDbContext bankdbcontext = new BankDbContext();
ITransactionService _transactionService = new TransactionService(bankdbcontext);
ICardService _cardService = new CardService(bankdbcontext);
Card CurrentCard = new Card();

while (true)
{

    Console.WriteLine("====== Welcome To MJ Bank System ======");

    Console.WriteLine("Card Number: ");
    string cardNumber = Console.ReadLine();
    Console.WriteLine("Password: ");
    string password = Console.ReadLine();

    if (cardNumber != null || password != null)
    {
        if (_cardService.login(cardNumber, password))
        {
            CurrentCard = _cardService.GetByCardNumber(cardNumber);
            if (CurrentCard.TryToEnterTimes < 3 && CurrentCard.IsActive)
            {
                Menu();
            }
            else
            {
                CurrentCard.IsActive = false;
                Console.WriteLine("You tried to enter more than 3 times! your account blocked now. call Bank to solve the problem");
            }
        }
        else
        {
            Console.WriteLine("Your Card Number or passowrd is wrong");

            var result = _cardService.GetByCardNumber(cardNumber);
            if (result != null)
            {
                result.TryToEnterTimes++;
            }
            else
            {
                break;
            }
        }
    }
}

void Menu()
{
    Console.Clear();
    Console.WriteLine("1. Transfer Money");
    Console.WriteLine("2. View my last Transaction");
    Console.WriteLine("3. View my Balance");
    Console.WriteLine("4. Logout");

    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.WriteLine("Enter Destination Cart Number: ");
            string desid = Console.ReadLine();
            if (desid.Length == 16)
            {
                Console.WriteLine("enter amount: ");
                float amount = float.Parse(Console.ReadLine());
                if (amount < CurrentCard.Balance)
                {
                    if (amount > 0)
                    {
                        _transactionService.Transfer(CurrentCard.CardNumber, desid, amount);
                        Console.WriteLine("transfer has been successful!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("amount is not valid!");
                    }
                }
                else
                {
                    Console.WriteLine("Your Balance is not Enough!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Destination Id is not valid! more or less that 16 digit");
            }
            break;
        case 2:
            Console.Clear();
            var transactions = _transactionService.GetById(CurrentCard.Id);
            Console.WriteLine($"Last transactions for {CurrentCard.HolderName}: \n");
            foreach (var item in transactions)
            {
                Console.WriteLine($"{item.TransactionId}. from: {item.SourceCardNumber} - " +
                    $"to : {item.DestinationCardNumber} - amount: {item.Amount} - Date : {item.TransactionDate}");
            }
            break;
        case 3:
            Console.Clear();
            Console.Write($"dear{CurrentCard.HolderName}, your balance is {CurrentCard.Balance}");
            break;
        case 4:
            CurrentCard = null;
            break;
    }
}