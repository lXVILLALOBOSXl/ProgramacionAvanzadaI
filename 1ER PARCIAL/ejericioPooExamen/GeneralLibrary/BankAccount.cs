using System;

namespace GeneralLibrary
{
    public class BankAccount
    {
        public string name;
        private DateTime dateofBirth;
        private decimal amount;
        private int numAccount;
        public BankAccount(string name, DateTime dateOfBirth, decimal amount, int numAccount){
            amount += this.amount;
            name = this.name;
            dateOfBirth = this.dateofBirth;
            numAccount = this.numAccount;
        }

        public string getName(){
            return name;
        }
    
    }
}
