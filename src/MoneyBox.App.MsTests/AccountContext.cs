using Moneybox.App.Models;

namespace MoneyBox.App.MsTests
{
    /// <summary>
    /// Base Class Account contains all Model Behaviours to be tested.
    /// This is a Harness with dummy methods DepositMoney, WithdrawMoney and TransferMoney.
    /// What will really be tested is the Model Object with behaviours (Account)
    /// </summary>
    public class AccountContext: Account
    {
        
        public decimal TransferMoney(decimal amount)
        {
            return amount;
        }
        public decimal DepositMoney(decimal amount)
        {
            return amount;
        }

        public decimal WithdrawMoney(decimal amount)
        {
            return amount;
        }
    }
}
