using System;
using Moneybox.App.Models;

namespace Moneybox.App.DataAccess
{
    public interface IUserRepository
    {
        User GetUserById(Guid userId);
    }
}
