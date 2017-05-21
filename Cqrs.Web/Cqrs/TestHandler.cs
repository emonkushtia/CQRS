namespace Cqrs.Web.Cqrs
{
    using System.Threading.Tasks;

    public class TestHandler : ICommandHandler<TestCommand, TestResult>
    {
        public async Task<TestResult> Handle(TestCommand command)
        {
            return await Task.FromResult(new TestResult { Name = "Emon" });
        }
    }
}
