using Core._01_Services;
using Core._01_Services.Interfaces;
using Core._02_Repository;
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
//usario
builder.Services.AddScoped<IusuarioReposytor, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioservice, UsuarioService>();
//endereco
builder.Services.AddScoped<IEnderecoReposytor, EnderecoRepository>();
builder.Services.AddScoped<IEnderecoservice, EnderecoService>();
//produto
builder.Services.AddScoped<IProdutoReposytor, ProdutoRepository>();
builder.Services.AddScoped<IProdutoservice, ProdutoService>();
//venda
builder.Services.AddScoped<IVendaReposytor, Vendarepositor>();
builder.Services.AddScoped<IVendaservice, vendaservice>();
//carrinho
builder.Services.AddScoped<ICarrinhoreposytor1, CarrinhoRepository>();
builder.Services.AddScoped<ICarrinhoservice, CarrinhoService>();



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
