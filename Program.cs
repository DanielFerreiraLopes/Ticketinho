using Microsoft.EntityFrameworkCore;
using Ticketinho.Adapters;
using Ticketinho.Eventos.Application.Interfaces;
using Ticketinho.Eventos.Application.UseCases;
using Ticketinho.Eventos.Presentation.Interfaces;
using Ticketinho.Eventos.Repositories;
using Ticketinho.Infrastructure.Persistence;
using Ticketinho.Vendas.Application.Interfaces;
using Ticketinho.Vendas.Application.UseCases;
using Ticketinho.Vendas.Presentation.Interfaces;
using Ticketinho.Vendas.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// LIBERANDO O CORS PARA O FRONTEND
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IListEventUseCase, ListEventUseCase>();
builder.Services.AddScoped<IFindEventUseCase, FindEventUseCase>();
builder.Services.AddScoped<ICreateEventUseCase, CreateEventUseCase>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IOrderEventRepository, OrderEventRepository>();
builder.Services.AddScoped<IOrderDomainRepository, OrderDomainRepository>();
builder.Services.AddScoped<IOrderTicketRepository, OrderTicketRepository>();
builder.Services.AddScoped<IOrderTicketUseCase, OrderTicketUseCase>();
builder.Services.AddScoped<IGetTicketsByDocumentUseCase, GetTicketsByDocumentUseCase>();
builder.Services.AddScoped<IListOrdersUseCase, ListOrdersUseCase>();
builder.Services.AddScoped<IFindOrderUseCase, FindOrderUseCase>();
builder.Services.AddScoped<IPaymentAdapter, PaymentAdapter>();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();
app.UseHttpsRedirection();

// ATIVANDO O CORS AQUI (Tem que ser antes do UseAuthorization)
app.UseCors("AllowAll");

app.UseAuthorization();
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