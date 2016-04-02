using System;
using System.Collections.Generic;
using System.Linq;
using UniQode.Common;
using UniQode.Common.Utils;
using UniQode.Contracts;
using UniQode.Contracts.Services;
using UniQode.Data;
using UniQode.Entities.Data;

namespace UniQode.Services
{
    public class AccountService : IAccountService
    {
        public AccountService(IAdminRepository<Account> repository, ICacheProvider cacheProvider)
        {
            _repository = repository;
            _cacheProvider = cacheProvider;
        }

        private readonly IAdminRepository<Account> _repository;
        private readonly ICacheProvider _cacheProvider;

        public Account Get(Guid id, bool invalidateCache = false)
        {
            var accounts = List(invalidateCache);
            return accounts.FirstOrDefault(a => a.Id.Equals(id));
        }

        public Account Get(string email, bool invalidateCache = false)
        {
            if(string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("An email must be provided!", nameof(email));
            
            email = email.ToLower();
            var accounts = List(invalidateCache);

            return accounts.FirstOrDefault(a => a.Email.Equals(email));
        }

        public ICollection<Account> List(bool invalidateCache = false)
        {
            const string cacheKey = "Accounts";

            if (invalidateCache)
                _cacheProvider.Invalidate(cacheKey);

            if (_cacheProvider.IsSet(cacheKey))
                return _cacheProvider.Get<ICollection<Account>>(cacheKey);

            var accounts = _repository.GetAll().ToList();

            if (accounts.Any())
                _cacheProvider.Set(cacheKey, accounts);

            return accounts;
        }

        public Account Login(string email, string password)
        {
            var data = Get(email);

            if (data == null)
                throw new ErrorCodeException(ErrorCode.AccountNotFound);
            
            var bruteForceCacheKey = $"BruteForceDetection_{email}";
            var bruteForceAttempts = 0;

            if (_cacheProvider.IsSet(bruteForceCacheKey))
                bruteForceAttempts = _cacheProvider.Get<int>(bruteForceCacheKey);

            if(bruteForceAttempts >= 5)
                throw new ErrorCodeException(ErrorCode.BruteForceDetected);

            if (!PasswordHash.VerifyPassword(password, data.HashedPassword))
            {
                bruteForceAttempts++;
                _cacheProvider.Set(bruteForceCacheKey, bruteForceAttempts, ttl: TimeSpan.FromMinutes(10));

                throw new ErrorCodeException(ErrorCode.PasswordMismatch);
            }

            return data;
        }

        public Account Create(string name, string email, string password)
        {
            try
            {
                var account = Get(email);

                if (account != null) 
                    throw new ErrorCodeException(ErrorCode.AccountAlreadyExists);

                account = new Account
                {
                    Name = name,
                    Email = email,
                    HashedPassword = PasswordHash.Create(password)
                };

                _repository.Add(account);
                _repository.Commit();

                // clear cache
                return Get(email, true);
            }
            catch (ErrorCodeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorCodeException(ErrorCode.AccountCreationFailed, ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var account = Get(id);

                if (account == null)
                    throw new ErrorCodeException(ErrorCode.AccountNotFound);

                _repository.Delete(account.Id);
                _repository.Commit();

                // clear cache
                List(true);
            }
            catch (ErrorCodeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorCodeException(ErrorCode.AccountDeletionFailed, ex);
            }
        }

        public void ResetPassword(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("An email must be provided!", nameof(email));

            email = email.ToLower();
            var account = _repository.Find(a => a.Email.Equals(email));

            if(account == null)
                throw new ErrorCodeException(ErrorCode.AccountNotFound);

            account.HashedPassword = PasswordHash.Create(password);

            _repository.Update(account);
            _repository.Commit();

            // clear cache
            List(true);
        }
    }
}