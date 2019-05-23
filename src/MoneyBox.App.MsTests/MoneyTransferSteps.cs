using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MoneyBox.App.MsTests
{
    [Binding]
    public class MoneyTransferSteps
    {
        //Arrange
        private decimal newBalance = 0;
        private decimal amountToSend = 0;
        private AccountContext account = new AccountContext();
        private Guid from;
        private Guid to;

        [Given(@"I have entered (.*) into the TransferAmount field")]
        public void GivenIHaveEnteredIntoTheTransferAmountField(decimal amount)
        {
            account.Id = from;
            amountToSend = amount;
        }
        
        [Given(@"I have also a balance of (.*) in my acount")]
        public void GivenIHaveAlsoABalanceOfInMyAcount(decimal balance)
        {
            account.Balance = balance;
        }
        
        [When(@"I press TransferMoney")]
        public void WhenIPressTransferMoney()
        {
            account.TransferMoney(amountToSend);
        }
        
        [Then(@"the System should check if I have enough funds")]
        public void ThenTheSystemShouldCheckIfIHaveEnoughFunds()
        {
           Assert.AreEqual(account.ValidateAccountBeforeTransfering(from, amountToSend), true);
        }

        [Then(@"that I am not transferring money to the same account")]
        public void ThenThatIAmNotTransferringMoneyToTheSameAccount()
        { 
           Assert.AreEqual(account.AccountIdsAreDifferent(from, to),true);
        }

        [Then(@"that the balance in my account is updated to reflect the transfer")]
        public void ThenThatTheBalanceInMyAccountIsUpdatedToReflectTheTransfer()
        {
            newBalance = account.UpdateBalanceAfterWithdrawn(amountToSend);
            Assert.AreEqual(newBalance, account.Balance);
        }
    }
}
