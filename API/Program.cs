using Core._01_Services.Interfaces;
using Core._02_Repository.Interfaces;
using TrabalhoFinal._01_Services;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._02_Repository.Data;
using TrabalhoFinal._03_Entidades.DTOs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
InicializadorBd.Inicializar();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IusuarioReposytor, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioservice, UsuarioService>();



//Aqui apra baixo as injeções ja devem ter sido feitas
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
