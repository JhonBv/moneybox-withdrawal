using System;
using Moneybox.App.DataAccess;

namespace Moneybox.App.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
