namespace Cqrs.Web.Controllers
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Autofac;

    using Cqrs;

    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private readonly ICommandBus commandBus;

        public TestController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        [Route("all")]
        public async Task<HttpResponseMessage> Get()
        {
            var command = new TestCommand();
            return await new ActionResponder<TestResult>(this.commandBus, this).RespondTo(command);
        }
    }
}
