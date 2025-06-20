var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapGet("/products", () =>
    {
        return Results.Ok(new[] {"Product1", "Product2", "Product3.1"});
    })
    .WithName("GetProducts")
    .WithOpenApi();

app.MapGet("/", ()=> Results.Ok());

app.Run();