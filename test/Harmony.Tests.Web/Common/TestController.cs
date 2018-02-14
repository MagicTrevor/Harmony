using System;
using Harmony.Data;
using Harmony.Web;

namespace Harmony.Tests.Web {
    public class TestsController : ApiController<TestEntity, Guid> {

        public TestsController(IReadOnlyRepository repository) : base(repository) {}
    }
}