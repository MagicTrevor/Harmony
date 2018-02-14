using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Harmony.Data.EntityFrameworkCore;
using Xunit;

namespace Harmony.Tests.Data.EntityFrameworkCore
{
    public class RepositoryTests
    {

        [Fact]
        public void AddSingle()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "only_one_result")
                .Options;

            var context = new TestDbContext(options);

            var testEntity = new TestEntity();

            var repository = new TestRepository<TestDbContext>(context);
            repository.Insert<TestEntity>(testEntity);

            var result = repository.Get<TestEntity>(testEntity.Id);

            Assert.True(result != null);
        }
    }
}
