using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Harmony.Data.EntityFrameworkCore;
using Xunit;

namespace Harmony.Tests.Data.EntityFrameworkCore
{
    public class ReadOnlyRepositoryTests
    {
        public ReadOnlyRepositoryTests()
        {
        }

        [Fact]
        public void OnlyOneResult()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "only_one_result")
                .Options;

            var context = new TestDbContext(options);

            var testEntity = new TestEntity();
            context.Entities.Add(testEntity);
            context.SaveChanges();

            var repository = new ReadOnlyRepository<TestDbContext>(context);
            var items = repository.GetAllAsync<TestEntity>().Result;

            Assert.True(items.Count().Equals(1));
        }

        [Fact]
        public void FindSingle()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "find_single")
                .Options;

            var context = new TestDbContext(options);

            var testEntity = new TestEntity();

            var testEntity2 = new TestEntity();

            context.Entities.Add(testEntity);
            context.Entities.Add(testEntity2);
            context.SaveChanges();

            var repository = new ReadOnlyRepository<TestDbContext>(context);
            var item = repository.GetAsync<TestEntity>(testEntity.Id).Result;

            Assert.Equal(testEntity.Id, item.Id);
        }
    }
}
