using JogadorAPI.Data;
using JogadorAPI.Repositories;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient(x =>
    new MySqlConnection(ApiDapperContext.CONNECTION_STRING_LOCAL));
builder.Services.AddTransient<UsuarioRepository>();

//builder.Services.AddSwaggerGen();

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
app.Run();
