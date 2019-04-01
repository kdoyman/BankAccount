---------------------------------------------------------Program.cs :

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_system
{
   
    class Program
    {

        static void Main(string[] args)
        {
            

            string temp;
            string temp2;
            string templong;
            int Choice;
            bool elegxos1=true, elegxos2=true;
            List<Customer> ListOfCustomers = new List<Customer>();
            decimal poso;

            Console.WriteLine("\n\n----------BUILT PROCESS------------\n\n");
            Console.WriteLine("\nPlease Enter Your First Name");
            temp = Console.ReadLine();
            Console.WriteLine("Please Enter Your Last Name");
            temp2 = Console.ReadLine();
            
           
            do
            {
                Console.WriteLine("Enter 1 to create a Savings Account \a, 2 to create a Credits Account \nor 3 to create a Lottery Account");
                Choice = Convert.ToInt32(Console.ReadLine());
               
                switch (Choice)
                {
                    case 1:
                        SavingsAccount sav_new = new SavingsAccount(temp,temp2,"");
                        Console.WriteLine("create account: Savings");
                        Console.WriteLine("customer: {0} {1}",temp,temp2);
                        ListOfCustomers.Add(sav_new);
                        elegxos1 = true;
                        break;
                        
                    case 2:
                        CreditsAccount cre_new = new CreditsAccount(temp, temp2,"");
                        Console.WriteLine("create account: Credits");
                        Console.WriteLine("customer: {0} {1}", temp, temp2);
                        ListOfCustomers.Add(cre_new);
                        elegxos1 = true;
                        break;
                        
                    case 3:
                        LotteryAccount lot_new = new LotteryAccount(temp, temp2,"");
                        Console.WriteLine("create account: Lottery");
                        Console.WriteLine("customer: {0} {1}", temp, temp2);
                        ListOfCustomers.Add(lot_new);
                        elegxos1 = true;
                        break;
                    default:
                        Console.WriteLine("Try again");
                        elegxos1 = false;
                        break;
                        

                }
            } while (!elegxos1);
            // foreach(Customer j in Customers)
            Console.WriteLine("\n\n----------MAIN PROCESS------------\n\n");

            switch (Choice)
            {
                case 1:
                    var savinCustomers = from kk in ListOfCustomers
                                         where kk.ar_logariasmoy == 1
                                         select kk;
                    foreach (var kk in savinCustomers) { };
                    
                    break;
                case 2:
                    var creditCustomers = from kk in ListOfCustomers
                                         where kk.ar_logariasmoy == 2
                                         select kk;
                    foreach (var kk in creditCustomers) { };
                    break;
                case 3:
                    var loteryCustomers = from kk in ListOfCustomers
                                         where kk.ar_logariasmoy == 3
                                         select kk;
                    foreach (var kk in loteryCustomers) { };
                    break;



            }
            do
            {
              
                do
                {
                    Console.WriteLine("Press 1 for withdraw , 2 for deposit , 3 for print or 4 to quit");
                    Choice = Convert.ToInt32(Console.ReadLine());
                    

                    if (DateTime.Now.DayOfYear == 365) { foreach (Customer k in ListOfCustomers) { k.Addinterest(); k.Addpayment(); } }

                    if (Choice == 4) { break; }

                    switch (Choice)
                    {
                        case 1:
                            Console.WriteLine("Eisagete to poso for withdraw:");
                            poso = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("poso =" + poso+" $");
                            
                            foreach (Customer k in ListOfCustomers)
                            {

                                // sav_new.Balance = k.Balance-poso;
                                k.Withdraw(poso);
                                Console.WriteLine("soy menoyn :\n\t" + k.Balance);
                               // Bill neo = new Bill();
                              //  neo.date=DateTime.Now;
                              //  neo.reason="WITHDRAW";
                              //  neo.amount=poso;
                             //   neo.balance=k.Balance;
                             //   k.kinhseis.Add(neo);

                            }
                            elegxos2 = false;
                            
                            break;

                        case 2:
                            Console.WriteLine("Eisagete to poso for deposit:");
                            poso = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("evales :"+poso);
                          
                            foreach (Customer k in ListOfCustomers)
                            {
                                k.Deposit(poso);
                               // Bill neo = new Bill();
                               // neo.date = DateTime.Now;
                               // neo.reason = "DEPOSIT";
                               // neo.amount = poso;
                               // neo.balance = k.Balance;
                               // k.kinhseis.Add(neo);
                                
                            }
                            elegxos2 = false;
                            break;
                        case 3:
                            foreach(Customer k in ListOfCustomers) { k.print(); }
                            elegxos2 = false;
                            break;
                        default:
                            elegxos2 = true;
                            break;
                    }
                } while (elegxos2);
                if(Choice == 4) { break; }
            } while (true);


            
               
        }
    }
}


---------------------------------------------------------------Customer.cs :

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_system
{
    class Customer:should_have
    {
        private string firstname;
        private string lastname;
        private string iban;
        private decimal balance = 0.0M;
        public decimal transLimt=10000M;
        public int ar_logariasmoy = 0;

        public static List<Bill> kinhseis = new List<Bill> { };

        public Customer(string first,string last,string ibn)
        {
            firstname = first;
            lastname = last;
            iban = ibn;
            
        }
        public string Firstname { get { return firstname;} set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Iban { get { return iban; } set { iban= value; } }
        virtual public void print()
        {
            Console.WriteLine($"{firstname} {lastname} {iban}");
        }
        public decimal Balance
        {
            get { return balance; }
            set => balance = value;
        }
        virtual public decimal Deposit(decimal ammount) { return Balance; }
        virtual public decimal Withdraw(decimal ammount) { return Balance; }
        public virtual void Addinterest() { }
        public virtual void Addpayment() { }
    }

    public interface should_have
    {

        void print(); 
    }
}

-----------------------------------------------------------SavingsAccount.cs :

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


--------------------------------------------------------------CreditsAccount.cs :

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


----------------------------------------------------------------------LotteryAccount.cs :

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_system
{
    internal class LotteryAccount:Customer
    {
        string temp, temp2,iban2;
        private decimal InterestRate = 0.15m;
        decimal Winpercentage = 0.005m;
        int WinAmmount = 21;



        public LotteryAccount(string first, string last, string ibn) : base(first, last, ibn)
        {
            Random rt = new Random();
            iban2 = Convert.ToString(rt.Next(1147483, 2147483));
            Firstname = first;
            Lastname = last;
            Iban = iban2;
            Console.WriteLine("Your new IBAN is : \a" + Iban);
            ar_logariasmoy = 3;
        }

        public override void print()
        {
            Console.WriteLine("DATE        | REASON | AMOUNT  | BALANCE" +
               "\n------------|---------|----------------\n");
            foreach (Bill kh in kinhseis) { Console.WriteLine($"{kh.date}        | {kh.reason} | {kh.amount}  | {kh.balance}"); }
        }
        public override void Addinterest()
        {
            decimal tempo = Balance * InterestRate;
            Balance =Balance + tempo;
            Bill eggrafh = new Bill();
            eggrafh.date = DateTime.Now;
            eggrafh.reason = "INTEREST";
            eggrafh.amount = tempo;
            eggrafh.balance = Balance;
            kinhseis.Add(eggrafh);
        }
        public override decimal Withdraw(decimal ammount)
        {
            if (transLimt - ammount >= 0)
            {
                if (Balance - ammount >= 0)
                {

                    if (ammount > 0)
                    {
                        Balance = Balance - ammount;
                        Bill eggrafh = new Bill();
                        eggrafh.date = DateTime.Now;
                        eggrafh.reason = "WITHDRAW";
                        eggrafh.amount = ammount;
                        eggrafh.balance = Balance;
                        kinhseis.Add(eggrafh);
                        Winpercentage = Winpercentage * 2;
                        if (Winpercentage >= 1) { Balance = Balance + WinAmmount; Winpercentage=0.25m;
                            Bill eggrafh2 = new Bill();
                            eggrafh2.date = DateTime.Now;
                            eggrafh2.reason = "LOTTARY WIN";
                            eggrafh2.amount = ammount;
                            eggrafh2.balance = Balance;
                            kinhseis.Add(eggrafh2);
                        }
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
                Balance = Balance + ammount;
                Winpercentage = Winpercentage * 3;
                if (Winpercentage >= 1) { Balance = Balance + WinAmmount;Winpercentage = 0.25m;
                    Bill eggrafh2 = new Bill();
                    eggrafh2.date = DateTime.Now;
                    eggrafh2.reason = "LOTTARY WIN";
                    eggrafh2.amount = ammount;
                    eggrafh2.balance = Balance;
                    kinhseis.Add(eggrafh2);
                }
                Bill eggrafh = new Bill();
                eggrafh.date = DateTime.Now;
                eggrafh.reason = "DEPOSIT";
                eggrafh.amount = ammount;
                eggrafh.balance = Balance;
                kinhseis.Add(eggrafh);
                Console.WriteLine("balance= " + Balance);
            }
            else { Console.WriteLine("\nNegative input\n"); }

            return Balance;

        }

    }
}


--------------------------------------------------------------Bill.cs :

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_system
{
    internal class LotteryAccount:Customer
    {
        string temp, temp2,iban2;
        private decimal InterestRate = 0.15m;
        decimal Winpercentage = 0.005m;
        int WinAmmount = 21;



        public LotteryAccount(string first, string last, string ibn) : base(first, last, ibn)
        {
            Random rt = new Random();
            iban2 = Convert.ToString(rt.Next(1147483, 2147483));
            Firstname = first;
            Lastname = last;
            Iban = iban2;
            Console.WriteLine("Your new IBAN is : \a" + Iban);
            ar_logariasmoy = 3;
        }

        public override void print()
        {
            Console.WriteLine("DATE        | REASON | AMOUNT  | BALANCE" +
               "\n------------|---------|----------------\n");
            foreach (Bill kh in kinhseis) { Console.WriteLine($"{kh.date}        | {kh.reason} | {kh.amount}  | {kh.balance}"); }
        }
        public override void Addinterest()
        {
            decimal tempo = Balance * InterestRate;
            Balance =Balance + tempo;
            Bill eggrafh = new Bill();
            eggrafh.date = DateTime.Now;
            eggrafh.reason = "INTEREST";
            eggrafh.amount = tempo;
            eggrafh.balance = Balance;
            kinhseis.Add(eggrafh);
        }
        public override decimal Withdraw(decimal ammount)
        {
            if (transLimt - ammount >= 0)
            {
                if (Balance - ammount >= 0)
                {

                    if (ammount > 0)
                    {
                        Balance = Balance - ammount;
                        Bill eggrafh = new Bill();
                        eggrafh.date = DateTime.Now;
                        eggrafh.reason = "WITHDRAW";
                        eggrafh.amount = ammount;
                        eggrafh.balance = Balance;
                        kinhseis.Add(eggrafh);
                        Winpercentage = Winpercentage * 2;
                        if (Winpercentage >= 1) { Balance = Balance + WinAmmount; Winpercentage=0.25m;
                            Bill eggrafh2 = new Bill();
                            eggrafh2.date = DateTime.Now;
                            eggrafh2.reason = "LOTTARY WIN";
                            eggrafh2.amount = ammount;
                            eggrafh2.balance = Balance;
                            kinhseis.Add(eggrafh2);
                        }
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
                Balance = Balance + ammount;
                Winpercentage = Winpercentage * 3;
                if (Winpercentage >= 1) { Balance = Balance + WinAmmount;Winpercentage = 0.25m;
                    Bill eggrafh2 = new Bill();
                    eggrafh2.date = DateTime.Now;
                    eggrafh2.reason = "LOTTARY WIN";
                    eggrafh2.amount = ammount;
                    eggrafh2.balance = Balance;
                    kinhseis.Add(eggrafh2);
                }
                Bill eggrafh = new Bill();
                eggrafh.date = DateTime.Now;
                eggrafh.reason = "DEPOSIT";
                eggrafh.amount = ammount;
                eggrafh.balance = Balance;
                kinhseis.Add(eggrafh);
                Console.WriteLine("balance= " + Balance);
            }
            else { Console.WriteLine("\nNegative input\n"); }

            return Balance;

        }

    }
}
