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
