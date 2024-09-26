using Bank.Business.IService;
using Bank.Business.Mapping;
using Bank.Business.Service;
using Bank.DataAccess;
using Bank.DataAccess.Entities;
using Bank.DataAccess.Interfaces;
using Bank.DataAccess.Repositories;
using BankAPI.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BankContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myCon")));


builder.Services.AddIdentity<Customer, IdentityRole>()
    .AddEntityFrameworkStores<BankContext>();
    

//builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
//builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// Register services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<ITransactionHistoryService, TransactionHistoryService>();
//services.AddScoped<IAuthService, AuthService>();



builder.Services.AddAutoMapper(typeof(Program));



builder.Services.AddControllers();//.AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenJwtAuth();
builder.Services.AddCustomJwtAuth(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();