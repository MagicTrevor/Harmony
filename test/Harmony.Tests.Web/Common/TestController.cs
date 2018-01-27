using System;
using Harmony.Data;
using Harmony.Web;

namespace Harmony.Tests.Web {
    public class TestsController : ApiController<TestEntity, Guid> {

        public TestsController(IReadOnlyRepository<TestEntity, Guid> repository) : base(repository) {}
    }
}