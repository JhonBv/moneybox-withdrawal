# Moneybox Money Withdrawal

The solution contains a .NET core library (Moneybox.App) which is structured into the following 3 folders:

* Domain - this contains the domain models for a user and an account, and a notification service.
* Features - this contains two operations, one which is implemented (transfer money) and another which isn't (withdraw money)
* DataAccess - this contains a repository for retrieving and saving an account (and the nested user it belongs to)

## The task

The task is to implement a money withdrawal in the WithdrawMoney.Execute(...) method in the features folder. For consistency, the logic should be the same as the TransferMoney.Execute(...) method i.e. notifications for low funds and exceptions where the operation is not possible.

As part of this process however, you should look to refactor some of the code in the TransferMoney.Execute(...) method into the domain models, and make these models less susceptible to misuse. We're looking to make our domain models rich in behaviour and much more than just plain old objects, however we don't want any data persistance operations (i.e. data access repositories) to bleed into our domain. This should simplify the task of implementing WithdrawMoney.Execute(...).

## Guidelines

* You should spend no more than 1 hour on this task, although there is no time limit
* You should fork or copy this repository into your own public repository (Github, BitBucket etc.) before you do your work
* Your solution must compile and run first time
* You should not alter the notification service or the the account repository interfaces
* You may add unit/integration tests using a test framework (and/or mocking framework) of your choice
* You may edit this README.md if you want to give more details around your work (e.g. why you have done something a particular way, or anything else you would look to do but didn't have time)

Once you have completed your work, send us a link to your public repository.

Good luck!

##Code Refactoring

The **Account** class had only properties and all of the Business Logic were written in the Features classes. This is ok for very small systems and if the **Account** class was to be uses as a Properties bag so that it can represent a storage structure, however, as per the requirement, the **Account** model needed to be rich and had Behaviour.

According to the principals of DDD abd BDD, the Rich Model Object should contain behaviour that will encapsulate its own logic without injecting any dependencies and without communicating with any persistance objects such as a Repositoy. So, in its most basic, the model now handles it own logic, which is within the *context* of **Account Transactions** and nothing more. There are no external classes/objects, no dependencies whatsoever and that makes it easy to fully Unit test it in a Behavioural way. To achieve Behavioural testing, I used SpecFlow 3.

## Structural changes in the project
The are no structural changes to the App project.

A new Project *MoneyBox.App.MsTests* has been added with all the necessary Nuget packages to carry on integration and unit testing,

## Dependencies
The MoneyBox.App.MsTests project uses the following libraries:

 * **SpecFlow 3.0.213**
 * **SpecFlow.Tools.MsBuild.Generation 3.0.213**
 * **SpecRun.SpecFlow 3.0.344**

As well as the

* **MSTest Framework** &
* **MSTest Adapter 1.3.2**

SpecFlow is an excellent library to perform tests of this nature so I decided to use the library. More can be found at the following Url: [SpecFlow 3.](https://specflow.org/getting-started/)



In the Test project there Three (3) Features each with Test scenarios based on the functionality that will be tested.
Below each Feature there is a file named after the feature and ends with Steps. So, for the MoneyDeposit.feature, the MoneyDepositSteps.cs file lies directly below.

The *Steps file contains all the steps for testing the feature.

## What could be done better?
Time permitting, a stronger testing harness could be created by adding a proper Mock<Accounts> by using the MOQ library and then use FluentAssertions to perform the Assertions.

Better produced Test Scenarios could help in future development as well.
