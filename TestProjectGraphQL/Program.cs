using TestProjectGraphQL.Configration;
using TestProjectGraphQL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<TestProjectGraphQL.ConfigrationSettings.Braintree>(builder.Configuration.GetSection("Braintree"));
builder.Services.AddScoped<IBraintreeConfiguration, BraintreeConfiguration>();
builder.Services.AddScoped<ITransactionService, TransactionService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
