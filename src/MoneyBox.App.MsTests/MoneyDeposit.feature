Feature: MoneyDeposit
	In order to add money to an account
	As a user
	I want to be able to successfully add funds to my account and be notified if I have reached the limit of paid in money
	so that I can manage my account effectively.

@MoneyTransactions
Scenario: Deposit Money
	Given I have entered 300 into the deposit amount field
	And I have also a balance of 700 in my acount
	When I press DepositMoney
	Then the system will add my funds to my account
	And the system should update my account balance