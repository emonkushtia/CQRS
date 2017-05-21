namespace Cqrs.Web.Cqrs
{
    using System;
    using System.Threading.Tasks;

    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, object> resolver;

        private readonly Type genericCommandHandlerType = typeof(ICommandHandler<,>);

        public CommandBus(Func<Type, object> resolver)
        {
            this.resolver = resolver;
        }

        public async Task<TResult> SendTo<TResult>(object command)
        {
            var handlerType = this.genericCommandHandlerType.MakeGenericType(command.GetType(), typeof(TResult));
            dynamic handler = this.resolver(handlerType);
            var result = await handler.Handle((dynamic)command);
            return result;
        }
    }
}
