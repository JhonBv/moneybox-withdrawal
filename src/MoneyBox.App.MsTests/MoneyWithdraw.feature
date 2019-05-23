Feature: MoneyWithdraw
	In order to have some cash
	As a user
	I want to be able to withdraw money from my account

@MoneyTransactions
Scenario: Withdraw Money
	Given I have entered 300 into the amount field
	And I also have a balance of 700 in my acount
	When I press WithdrawMoney
	Then the System should check if I have enough funds
	And if I have enough funds on my account
	Then I will successfully be able to withdraw the amount
	And the system should update my account balance
