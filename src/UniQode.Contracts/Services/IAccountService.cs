using System;
using System.Collections.Generic;
using UniQode.Entities.Data;

namespace UniQode.Contracts.Services
{
    public interface IAccountService
    {
        Account Get(Guid id, bool invalidateCache = false);
        Account Get(string email, bool invalidateCache = false);
        ICollection<Account> List(bool invalidateCache = false);
        Account Login(string email, string password);
        Account Create(string name, string email, string password);
        void Delete(Guid id);
        void ResetPassword(string email, string password);
    }
}