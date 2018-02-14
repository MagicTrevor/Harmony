using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Harmony.Data.EntityFrameworkCore;
using Xunit;

namespace Harmony.Tests.Web
{
    public class ApiControllerTests
    {
        public ApiControllerTests()
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
            var controller = new TestsController(repository);

            var response = controller.List().Result;

            Console.WriteLine(response);

            Assert.True(response.Count().Equals(1));
        }
    }
}
