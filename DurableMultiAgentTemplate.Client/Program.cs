﻿using DurableMultiAgentTemplate.Client.Components;
using DurableMultiAgentTemplate.Client.Http;
using DurableMultiAgentTemplate.Client.Services;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

// Service Discovery and Retry Policy
builder.Services.AddServiceDiscovery();

builder.Services.ConfigureHttpClientDefaults(https =>
{
    https.AddStandardResilienceHandler();
    https.AddServiceDiscovery();
});

// Azure Functions Authentication
builder.Services.Configure<BackendOptions>(builder.Configuration.GetSection("Backend"));
builder.Services.AddTransient<AzureFunctionsApiKeyAuthenticationHttpMessageHandler>();

builder.Services.AddHttpClient<AgentChatService>(httpClient =>
    {
        httpClient.BaseAddress = new("https+http://backend");
    })
    .AddHttpMessageHandler<AzureFunctionsApiKeyAuthenticationHttpMessageHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
