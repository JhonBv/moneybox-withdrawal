Feature: MoneyTransfer
	In order to transfer funds to another account
	As a user
	I want to be able to enter the amount I want to transfer
	I also want to be able to select the account from where I want to withdraw the money
	I also want to be able to add the account to which I want to add money
	Then the system will check my balance and notify me if I have enough money
	And the system should allow me to complete the transaction if I have sufficient funds.

@MoneyTransactions
Scenario: Transfer Money Between Two Accounts
	Given I have entered 400 into the TransferAmount field
	And I have also a balance of 700 in my acount
	When I press TransferMoney
	Then the System should check if I have enough funds
	And that I am not transferring money to the same account
	And that the balance in my account is updated to reflect the transfer
