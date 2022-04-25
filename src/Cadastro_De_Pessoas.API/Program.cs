using Cadastro_De_Pessoas.APPLICATION.Services.CidadeService;
using Cadastro_De_Pessoas.APPLICATION.Services.PessoaService;
using Cadastro_De_Pessoas.INFRA.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
InjectionServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
}

void InjectionServices()
{
    builder.Services.AddTransient<IPessoaService, PessoaService>();
    builder.Services.AddTransient<ICidadeService, CidadeService>();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(
    c => c
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
    
    );

app.MapControllers();

app.Run();
