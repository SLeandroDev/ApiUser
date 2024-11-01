using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();
var app = builder.Build();

// Configura o pipeline de requisições HTTP.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();