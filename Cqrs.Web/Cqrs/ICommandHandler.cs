namespace Cqrs.Web.Cqrs
{
    using System.Threading.Tasks;

    public interface ICommandHandler<in TCommand, TResult>
    {
        Task<TResult> Handle(TCommand command);
    }
}
