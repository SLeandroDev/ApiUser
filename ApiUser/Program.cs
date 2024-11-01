using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllers();
var app = builder.Build();

// Configura o pipeline de requisi��es HTTP.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();