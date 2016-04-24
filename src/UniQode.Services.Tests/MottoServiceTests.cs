using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using UniQode.Contracts;
using UniQode.Contracts.Repositories;
using UniQode.Contracts.Services;
using UniQode.Data.Models;
using UniQode.Data.Repositories;
using UniQode.Entities.Data;
using UniQode.Services.Providers;
using Xunit;

namespace UniQode.Services.Tests
{
    public class MottoServiceTests
    {
        public MottoServiceTests()
        {
            var connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=UniQodeWeb;Integrated Security=true";
            _primaryRepository = new PrimaryRepository<Motto>(new PrimaryModel(connectionString));
            _secondaryRepository = new SecondaryRepository<Motto>(new SecondaryModel(connectionString));
            _service = new MultiTenantService<Motto, Guid>(_primaryRepository, _secondaryRepository, new DefaultCacheProvider(TimeSpan.FromMilliseconds(CacheTtlInMs)));

            _identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "test")
            }, AuthenticationTypes.Basic);
        }

        private const int CacheTtlInMs = 2000;
        private readonly IPrimaryRepository<Motto> _primaryRepository;
        private readonly ISecondaryRepository<Motto> _secondaryRepository;
        private readonly IMultiTenantService<Motto, Guid> _service;
        private readonly ClaimsIdentity _identity;
        private readonly Guid _mottoId = Guid.Parse("aff90c6b-3264-4493-a0a3-ddef5f04dc0c");

        private void Cleanup(params Guid[] ids)
        {
            if (ids == null || !ids.Any())
                ids = new List<Guid> {_mottoId}.ToArray();

            // do cleanup
            foreach (var id in ids)
            {
                try
                {
                    _service.Primary.Delete(id, _identity);
                }
                catch
                {
                    // supress
                }
            }
        }

        [Fact]
        public void Create_GivenSomeTestData_ShouldObserveCreatedEntity()
        {
            try
            {
                var motto = new Motto
                {
                    Id = _mottoId,
                    Title = "Test title",
                    Description = "Test description"
                };

                var result = _service.Primary.Create(motto, _identity);

                Assert.NotNull(result);
                Assert.Equal(motto, result);
            }
            finally
            {
                Cleanup();
            }
        }

        [Fact]
        public void CreateAndUpdate_GivenSomeTestData_ShouldObserveUpdatedEntity()
        {
            try
            {
                var title = "Test title";
                var description = "Test description";
                var motto = new Motto
                {
                    Id = _mottoId,
                    Title = title,
                    Description = description
                };

                var result = _service.Primary.Create(motto, _identity);

                Assert.NotNull(result);

                result.Title += " 2";
                result.Description += " 2";

                var result2 = _service.Primary.Update(result, _identity);

                Assert.NotNull(result2);
                Assert.Equal(_mottoId, result2.Id);
                Assert.NotEqual(title, result2.Title);
                Assert.NotEqual(description, result2.Description);

            }
            finally
            {
                Cleanup();
            }
        }

        [Fact]
        public void CreateAndList_Given3CreatedEntities_ShouldObserveTheSameAmountWhenListing()
        {
            var id1 = Guid.Parse("3a270c8d-dba6-4d99-b423-99fc50b7d10d");
            var id2 = Guid.Parse("c1d2a587-94b7-4184-9d4c-d25b65886a26");
            var id3 = Guid.Parse("877aac54-87a0-4e68-a91f-55653b14cf34");

            try
            {
                var motto1 = new Motto
                {
                    Id = id1,
                    Title = "Test title 1",
                    Description = "Test description 1"
                };
                var motto2 = new Motto
                {
                    Id = id2,
                    Title = "Test title 2",
                    Description = "Test description 2"
                };
                var motto3 = new Motto
                {
                    Id = id3,
                    Title = "Test title 3",
                    Description = "Test description 3"
                };

                var result1 = _service.Primary.Create(motto1, _identity);
                var result2 = _service.Primary.Create(motto2, _identity);
                var result3 = _service.Primary.Create(motto3, _identity);

                Assert.NotNull(result1);
                Assert.NotNull(result2);
                Assert.NotNull(result3);

                var list = _service.Primary.List();

                Assert.NotNull(list);
                Assert.Equal(3, list.Count);

            }
            finally
            {
                Cleanup(_mottoId, id1, id2, id3);
            }
        }
    }
}