using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_system
{
     class SavingsAccount:Customer,should_have
    {
        
        string temp, temp2, iban2;
        private decimal InterestRate = 0.1m;

        public SavingsAccount(string first,string last,string ibn ):base(first,last,ibn)
        {
            
            Random rt = new Random();
            iban2 = Convert.ToString(rt.Next(1147483, 2147483));
            Firstname = first;
            Lastname = last;
            Iban = iban2;
            Console.WriteLine("Your new IBAN is : \a" + Iban);
            ar_logariasmoy = 1;
        }

        public override decimal Withdraw(decimal ammount)
        {
            if (transLimt - ammount >= 0)
            {
                if (Balance - ammount >= 0)
                {                                                        

                    if (ammount > 0)
                    {                        
                        Balance = Balance -ammount;
                        Bill eggrafh = new Bill();
                        eggrafh.date = DateTime.Now;
                        eggrafh.reason = "WITHDRAW";
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
        public override decimal Deposit(decimal ammount)
        {

            if (ammount > 0)
            {
                Balance = Balance+ammount;
                Console.WriteLine(" balance = "+Balance);
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
        public override void Addinterest() {
            decimal tempo = Balance * InterestRate;
            Balance = Balance+tempo;
            Bill eggrafh = new Bill();
            eggrafh.date = DateTime.Now;
            eggrafh.reason = "INTEREST";
            eggrafh.amount = tempo;
            eggrafh.balance = Balance;
            kinhseis.Add(eggrafh);
        }

        public override void print()
        {
            Console.WriteLine("DATE        | REASON | AMOUNT  | BALANCE" +
                "\n------------|---------|----------------\n");
            foreach (Bill kh in kinhseis) { Console.WriteLine($"{kh.date}        | {kh.reason} | {kh.amount}  | {kh.balance}"); }
            
        }
    }
}
