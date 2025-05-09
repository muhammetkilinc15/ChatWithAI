using Chat_App.Extensions;
using Chat_App.Service;
using Microsoft.SemanticKernel;
using OpenAI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenAIChatCompletion(
    modelId: "meta-llama/llama-4-maverick:free",
    openAIClient: new OpenAIClient(
        credential: new ApiKeyCredential("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"),
        options: new OpenAIClientOptions
        {
            Endpoint = new Uri("https://openrouter.ai/api/v1")
        })
    );

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7062") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddSingleton<AIService>();
builder.Services.AddSignalR();

builder.Services.AddOpenApi();

var app = builder.Build();
app.MapChatAppEndpoints();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();
app.UseHttpsRedirection();


app.Run();
