namespace Cqrs.Web.Cqrs
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class ActionResponder<TResult>
    {
        private readonly ICommandBus commandBus;

        private readonly ApiController controller;

        public ActionResponder(ICommandBus commandBus, ApiController controller)
        {
            this.commandBus = commandBus;
            this.controller = controller;
        }

        public async Task<HttpResponseMessage> RespondTo(object command)
        {
            if (!this.controller.ModelState.IsValid)
            {
                return this.controller.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    this.controller.ModelState);
            }

            var result = await this.commandBus.SendTo<TResult>(command);
            if (result == null)
            {
                return this.controller.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Resource does not exist.");
            }

            return this.controller.Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
