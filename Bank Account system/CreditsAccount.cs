using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_system
{
    class CreditsAccount:Customer,should_have
    {
        
        string temp, temp2, iban2;
        decimal fee=0.25M, CreditLimit=3000M;
        private decimal InterestRate = 0.2m;

        public CreditsAccount(string first, string last,string ibn) : base(first,last,ibn)
        {
           
            Random rt = new Random();
            iban2 = Convert.ToString(rt.Next(1147483, 2147483));
            Firstname = first;
            Lastname = last;
            Iban = iban2;
            Console.WriteLine("Your new IBAN is : \a" + Iban);
            ar_logariasmoy = 2;

        }

        public override decimal Withdraw(decimal ammount)
        {
            if (CreditLimit-ammount>=0)
            {
                if (transLimt - ammount >= 0)
                {
                    if (Balance - ammount - (ammount*fee) >= 0)
                    {

                        if (ammount > 0)
                        {
                            Balance = Balance - ammount - (ammount * fee);
                            Console.WriteLine("you have been charged :" + (ammount+(ammount*fee)) + " $");
                            Bill eggrafh = new Bill();
                            eggrafh.date = DateTime.Now;
                            eggrafh.reason = "CHARGING";
                            eggrafh.amount = ammount;
                            eggrafh.balance = Balance;
                            kinhseis.Add(eggrafh);
                        }
                        else { Console.WriteLine("\nNegative input\n"); }
                        return Balance;
                    }
                    else
                    {
                        Console.WriteLine("try again the ammount is greater than your balance");
                        return Balance;
                    }
                }
                else
                {
                    Console.WriteLine($"{ammount} is more than the limit of {transLimt} .\n Please try again ! \a");
                    return Balance;
                }
            }
            else { Console.WriteLine("You have passed the credit limit"); return Balance; }
        }

        public override decimal Deposit(decimal ammount)
        {

            if (ammount > 0)
            {
                Balance = Balance + ammount;
                Console.WriteLine(" balance = " + Balance);
                Bill eggrafh = new Bill();
                eggrafh.date = DateTime.Now;
                eggrafh.reason = "DEPOSIT";
                eggrafh.amount = ammount;
                eggrafh.balance = Balance;
                kinhseis.Add(eggrafh);
            }
            else { Console.WriteLine("\nNegative input\n"); }
            return Balance;

        }

        public override void print()
        {
            Console.WriteLine("DATE        | REASON | AMOUNT  | BALANCE ( Fee = 25 % )" +
                "\n------------|---------|----------------\n");
            foreach (Bill kh in kinhseis) { Console.WriteLine($"{kh.date}     | {kh.reason} | {kh.amount}  | {kh.balance}"); }
        }
        public override void Addpayment()
        {
            decimal tempo = Balance * InterestRate;
            Balance = Balance-tempo;
            Bill eggrafh = new Bill();
            eggrafh.date = DateTime.Now;
            eggrafh.reason = "INTEREST CHARGE";
            eggrafh.amount = tempo;
            eggrafh.balance = Balance;
            kinhseis.Add(eggrafh);
        }
    }
}
