using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace MoneyBox.App.MsTests
{
    [Binding]
    public class MoneyWithdrawSteps
    {
        //Arrange
        private decimal newBalance = 0;
        private decimal amountToWithdraw = 0;
        private AccountContext account = new AccountContext();
        private Guid from;
        [Given(@"I have entered (.*) into the amount field")]
        public void GivenIHaveEnteredIntoTheAmountField(decimal amount)
        {
            account.Id = from;
            amountToWithdraw = amount;
        }

        [Given(@"I also have a balance of (.*) in my acount")]
        public void GivenIHaveAlsoABalanceOfInMyAcount(decimal balance)
        {
            account.Balance = balance;
        }

        [When(@"I press WithdrawMoney")]
        public void WhenIPressWithdrawMoney()
        {
            account.WithDrawMoney(amountToWithdraw);
        }
        
        [Then(@"if I have enough funds on my account")]
        public void ThenIfIHaveEnoughFundsOnMyAccount()
        {
            //Make sure account is valid and has enough funds.
            Assert.AreEqual(account.ValidateAccountBeforeWithdrwing(from, amountToWithdraw), true);
        }
        
        [Then(@"I will successfully be able to withdraw the amount")]
        public void ThenIWillSuccessfullyBeAbleToWithdrawTheAmount()
        {
            newBalance = account.Balance - amountToWithdraw;
            Assert.AreEqual(newBalance, account.UpdateBalanceAfterWithdrawn(amountToWithdraw));
        }
    }
}
