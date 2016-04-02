using System;
using System.Threading;
using UniQode.Contracts;
using UniQode.Contracts.Services;
using UniQode.Data.Models;
using UniQode.Data.Repositories;
using UniQode.Entities.Data;
using UniQode.Services.Cache;
using Xunit;

namespace UniQode.Services.Tests
{
    public class AccountServiceTests
    {
        public AccountServiceTests()
        {
            var connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=UniQodeWeb;Integrated Security=true";
            var context = new AdminModel(connectionString);
            _repository = new AdminRepository<Account>(context);
            _service = new AccountService(_repository, new DefaultCacheProvider(TimeSpan.FromMilliseconds(CacheTtlInMs)));
        }

        private readonly IAdminRepository<Account> _repository;
        private readonly IAccountService _service;
        private const int CacheTtlInMs = 2000;
        private const string Email1 = "test1@test.test";
        private const string Email2 = "test2@test.test";
        
        private void Cleanup()
        {
            // do cleanup
            try
            {
                var obj = _repository.Find(o => o.Email.Equals(Email1));

                if (obj != null)
                {
                    _repository.Delete(obj);
                    _repository.Commit();
                }
            }
            catch
            {
                // supress
            }

            try
            {
                var obj = _repository.Find(o => o.Email.Equals(Email2));

                if (obj != null)
                {
                    _repository.Delete(obj);
                    _repository.Commit();
                }
            }
            catch
            {
                // supress
            }
        }

        [Fact]
        public void CreateAndDelete_GivenEmail1_ShouldSucceed()
        {
            Cleanup();

            // Arrange
            var name = "name";
            var password = "password";

            //Act
            _service.Create(name, Email1, password);
            var result = _service.Get(Email1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Email1, result.Email);

            // Cleanup
            _service.Delete(result.Id);
            result = _service.Get(result.Id);

            // Assert
            Assert.Null(result);

            //Act
            result = _service.Get(Email1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetFromCache_GivenEmail1_ShouldInvalidateAfterCacheTtlInMs()
        {
            Cleanup();

            // Arrange
            var name = "name";
            var password = "password";

            //Act
            _service.Create(name, Email1, password);
            var result = _service.Get(Email1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Email1, result.Email);

            //Act
            result = _service.Get(result.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Email1, result.Email);

            // Cleanup
            _repository.Delete(result.Id);
            _repository.Commit();

            //Act
            result = _service.Get(result.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Email1, result.Email);

            //Act
            Thread.Sleep(CacheTtlInMs + 100);
            var result2 = _service.Get(result.Id);

            //Assert
            Assert.Null(result2);
        }
        
    }
}
