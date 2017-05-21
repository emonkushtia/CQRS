namespace Cqrs.Web.Cqrs
{
    using System.Threading.Tasks;

    public interface ICommandBus
    {
        Task<TResult> SendTo<TResult>(object command);
    }
}
