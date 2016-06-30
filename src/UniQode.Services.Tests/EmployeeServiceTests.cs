using System;
using System.Collections.Generic;
using System.Security.Claims;
using UniQode.Contracts.Repositories;
using UniQode.Contracts.Services;
using UniQode.Data.Models;
using UniQode.Data.Repositories;
using UniQode.Entities.Data;
using UniQode.Services.Providers;
using Xunit;

namespace UniQode.Services.Tests
{
    public class EmployeeServiceTests
    {
        public EmployeeServiceTests()
        {
            var connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=UniQodeWeb;Integrated Security=true";
            _primaryRepository = new PrimaryRepository<Employee>(new PrimaryModel(connectionString));
            _secondaryRepository = new SecondaryRepository<Employee>(new SecondaryModel(connectionString));
            _service = new MultiTenantService<Employee, Guid>(_primaryRepository, _secondaryRepository, new DefaultCacheProvider(TimeSpan.FromMilliseconds(CacheTtlInMs)));

            _identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "test")
            }, AuthenticationTypes.Basic);
        }

        private const int CacheTtlInMs = 2000;
        private readonly IPrimaryRepository<Employee> _primaryRepository;
        private readonly ISecondaryRepository<Employee> _secondaryRepository;
        private readonly IMultiTenantService<Employee, Guid> _service;
        private readonly ClaimsIdentity _identity;


        [Fact]
        public void Test()
        {
            var result = _service.Secondary.List();

            Assert.NotNull(result);
        }
    }
}