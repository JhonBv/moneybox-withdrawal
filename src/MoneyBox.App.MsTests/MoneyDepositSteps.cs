using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace MoneyBox.App.MsTests
{
    [Binding]
    public class MoneyDepositSteps
    {
        private decimal newBalance = 0;
        private decimal amountToDeposit = 0;
        private AccountContext account = new AccountContext();
        private Guid to;
        [Given(@"I have entered (.*) into the deposit amount field")]
        public void GivenIHaveEnteredIntoTheDepositAmountField(decimal amount)
        {
            account.Id = to;
            amountToDeposit = amount;
        }
        
        [Given(@"I also have a balance of (.*) in my account")]
        public void GivenIAlsoHaveABalanceOfInMyAccount(decimal balance)
        {
            Assert.IsNotNull(account.Balance = balance);
        }
        
        [When(@"I press DepositMoney")]
        public void WhenIPressDepositMoney()
        {
            account.DepositMoney(amountToDeposit);
        }
        
        [Then(@"the system will add my funds to my account")]
        public void ThenTheSystemWillAddMyFundsToMyAccount()
        {
            //Make sure Account is in valid state. No limit has been reached.
           Assert.AreEqual(account.ValidateAccountBeforeReceiving(to, amountToDeposit),true);
        }
        
        [Then(@"the system should update my account balance")]
        public void ThenTheSystemShouldUpdateMyAccountBalance()
        {
            newBalance = account.Balance + amountToDeposit;
            Assert.AreEqual(newBalance, account.UpdateBalanceAfterReceiving(amountToDeposit));
        }
      
    }
}
