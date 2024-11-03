using Microsoft.EntityFrameworkCore;
using WebApiGestãoPedidos.Data;
using WebApiGestãoPedidos.Services.Cliente;
using WebApiGestãoPedidos.Services.ItemPedido;
using WebApiGestãoPedidos.Services.Pedido;
using WebApiGestãoPedidos.Services.Produto;
using WebApiGestãoPedidos.Services.StatusPedido;
using WebApiGestãoPedidos.Services.TipoProduto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IClienteInterface, ClienteService>();
builder.Services.AddScoped<IPedidoInterface, PedidoService>();
builder.Services.AddScoped<IItemPedidoInterface, ItemPedidoService>();
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<IStatusPedidoInterface, StatusPedidoService>();
builder.Services.AddScoped<ITipoProdutoInterface, TipoProdutoService>();




// conexão com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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
