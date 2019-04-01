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
