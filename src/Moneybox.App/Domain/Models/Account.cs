using System;
using System.Threading.Tasks;

namespace Moneybox.App.Models
{
    public class Account
    {

        public const decimal PayInLimit = 4000m;

        public Guid Id { get; set; }
        public User User { get; set; }
        public decimal Balance { get; set; }
        public decimal Withdrawn { get; set; }

        //JB. Make sure Paying in account is not the same as the receiving account
        public decimal PaidIn { get; set; }


        /// <summary>
        /// Validate the Withdrawing account to make sure enough funds are available.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool ValidateAccountBeforeWithdrwing(Guid Id, decimal amount)
        {
            bool AccountValid = true;
            
            if (!HasAvailableFunds(Id, amount))
            {
                AccountValid = false;
                throw new InvalidOperationException("Insufficient funds to make transfer");
            }

            return AccountValid;
        }

        /// <summary>
        /// Validate the Transfering account to make sure enough funds are available.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool ValidateAccountBeforeTransfering(Guid Id, decimal amount)
        {
            bool AccountValid = true;
            //Make sure we don't accidentally check another account's balance
            if (!AccountIdsAreDifferent(this.Id, Id))
            {
                AccountValid = false;
                throw new InvalidOperationException("You cannot transfer money from and to the same account.");
            }

            return AccountValid;
        }

            /// <summary>
            /// Make sure Account has funds and also make sure we do not accidentally check a different account's balance 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="amount"></param>
            /// <returns></returns>
            public bool HasAvailableFunds(Guid id, decimal amount)
        {
            if (this.Id == id && Balance > amount) {
                return true;
            }
            return false;
        }        

        /// <summary>
        /// JB. Withdraw cash making sure that funds are available
        /// </summary>
        /// <param name="amount">the amount to be withdrawn. This applies when making any transfers as technically it will be a withdrawal.</param>
        /// <returns>Zero if the amount is greater than the balance, otherwise returns the amount</returns>
        public decimal WithDrawMoney(decimal amount)
        {
            if (!HasAvailableFunds(this.Id, amount))
                return 0m;
            else
            {
                UpdateBalanceAfterWithdrawn(amount);
                return amount;
            }
        }

        /// <summary>
        /// Update Balance
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>The new balance</returns>
        public decimal UpdateBalanceAfterWithdrawn(decimal amount)
        {
            this.Balance -= amount;
            UpdateWithdrawn(amount);
            return Balance;
        }

        /// <summary>
        /// Update withdrown amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>New withdrawn amount</returns>
        protected decimal UpdateWithdrawn(decimal amount)
        {
            this.Withdrawn -= amount;
            return Withdrawn;
        }

        /// <summary>
        /// Makes sure that the money is not Transferred to the same account i.e. Acc No: 1123 cannot transfer to itself.
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <returns></returns>
        public bool AccountIdsAreDifferent(Guid fromId, Guid toId)
        {
            bool areEqual = false;
            if (fromId.ToString() == toId.ToString())
            { areEqual = true;
            }
            return areEqual;
        }

        /// <summary>
        /// Make sure account has not reached PayInLimit
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="amount"></param>
        /// <returns>bool response</returns>
        public bool ValidateAccountBeforeReceiving(Guid Id, decimal amount)
        {
            bool AccountValid = true;
            if (PayInLimitCheck(amount) == 0m)
            {
                AccountValid = false;
                var available = PayInLimit - Balance;
                throw new InvalidOperationException("Account pay-in limit reached. You can deposit a maximum of "+ available.ToString());
            }
        
            return AccountValid;
        }

        public decimal ReceiveMoney(decimal amount)
        {

            return UpdateBalanceAfterReceiving(amount);

        }

        /// <summary>
        /// Makes sure amount is not over the pay-in limit
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal PayInLimitCheck(decimal amount)
        {
            if (PayInLimit < amount)
            {
                return 0m;
            }
            else
            {
                PaidIn += amount;
                return PaidIn;
            }
        }


        /// <summary>
        /// Update Balance after receiving funds
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>The updated balance</returns>
        public decimal UpdateBalanceAfterReceiving(decimal amount)
        {
            this.Balance += amount;
            UpdatePaidIn(amount);
            return Balance;
        }
        public decimal UpdatePaidIn(decimal amount)
        {
            this.PaidIn += amount;
            return PaidIn;
        }

    }
}
