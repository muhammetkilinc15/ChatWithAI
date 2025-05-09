using Chat_App.Hubs;
using Chat_App.Service;
using Chat_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Chat_App.Module
{
    public static class ChatModule
    {
        public static void MapChatApp(this IEndpointRouteBuilder app)
        {
            app.MapPost("/chat", async ([FromServices]AIService aiService,[FromBody] ChatRequestVM chatRequest, CancellationToken cancellation) =>
            {
                await aiService.GetMessageStreamAsync(chatRequest.Prompt, chatRequest.ConnectionId, cancellationToken: cancellation);
                return Results.Ok(new { message = "Mesaj AI servisine iletildi." }); 
            });


            app.MapHub<AIChatHub>("ai-hub");
        }
    }

   
}
