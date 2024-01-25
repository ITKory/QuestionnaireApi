using QuestionnaireApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.RegisterServices();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
