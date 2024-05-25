using JogadorAPI.Data;
using JogadorAPI.Repositories;
using MySql.Data.MySqlClient;

var AllowAll = "_allowAll";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(cors => cors.AddPolicy(name: AllowAll, policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient(x =>
    new MySqlConnection(ApiDapperContext.CONNECTION_STRING_LOCAL));

builder.Services.AddTransient<UsuarioRepository>();
builder.Services.AddTransient<JogadorRepository>();

//builder.Services.AddSwaggerGen();

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseCors(AllowAll);

app.MapControllers();
app.Run();
