using GiftCards.Api.Features.GiftCards;
using GiftCards.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("giftcards")
    .WithTags("GiftCards")
    .MapGiftCardEndpoints();

app.Run();
