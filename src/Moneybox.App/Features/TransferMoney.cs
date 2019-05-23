﻿using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using Moneybox.App.Models;
using System;

namespace Moneybox.App.Features
{
    public class TransferMoney
    {
        private IAccountRepository accountRepository;
        private INotificationService notificationService;

        public TransferMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            this.accountRepository = accountRepository;
            this.notificationService = notificationService;
        }

        public void Execute(Guid fromAccount, Guid toAccount, decimal amount)
        {
            var from = this.accountRepository.GetAccountById(fromAccount);
            var to = this.accountRepository.GetAccountById(toAccount);

            if (from.ValidateAccountBeforeTransfering(toAccount, amount) && to.ValidateAccountBeforeReceiving(toAccount, amount))
            {
                from.WithDrawMoney(amount);
                to.ReceiveMoney(amount);
                this.accountRepository.Update(from);
                this.accountRepository.Update(to);
            }

            if (from.Balance < 500m)
            {
                this.notificationService.NotifyFundsLow(from.User.Email);
            }

            if (Account.PayInLimit - to.PaidIn < 500m)
            {
                this.notificationService.NotifyApproachingPayInLimit(to.User.Email);
            }
        }
    }
}
