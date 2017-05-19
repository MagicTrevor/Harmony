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

            var repository = new ReadOnlyRepository<TestEntity, Guid>(context);
            var items = repository.GetAllAsync().Result;

            Assert.Equal(1, items.Count());
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

            var repository = new ReadOnlyRepository<TestEntity, Guid>(context);
            var item = repository.GetAsync(testEntity.Id).Result;

            Assert.Equal(testEntity.Id, item.Id);
        }
    }
}
