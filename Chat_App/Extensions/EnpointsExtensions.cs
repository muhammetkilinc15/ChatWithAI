using Chat_App.Module;

namespace Chat_App.Extensions
{
    public static class EndpointsExtensions
    {
        public static void MapChatAppEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapChatApp();
        }
    }
}
