using CRMWebAPI.BAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using System;

var builder = WebApplication.CreateBuilder(args);

string tenantId = "6f9e78e8-708c-4468-bddf-87291f9f7abc";
string Authority = "https://login.microsoftonline.com/" + tenantId + "/oauth2/token";
string ClientId = "25701525-ed19-4e41-9676-9d75dd8ec39d";
string ClientSecret = "3Tv8Q~ijssTRkoSsmA1xzihfPWi18HyVTJWwyboM";
//string ResourceUrl = "https://org1a8f658a.api.crm8.dynamics.com";
string ResourceUrl = "https://org8ca56ce5.api.crm8.dynamics.com";
string ApiVersion = "/api/data/v9.2";


builder.Services.AddSingleton(new CRMDynamicService(Authority, ClientId, ClientSecret, ResourceUrl, ApiVersion));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
