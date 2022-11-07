var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(
//    options =>
//{
//    options.AddPolicy(name: "MyJSPolicy", policy =>
//    {
//        policy.WithOrigins("http://127.0.0.1:5500")
//            .AllowAnyMethod()
//            .AllowAnyHeader();
//    });
//}
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(coarse => coarse.WithOrigins("http://127.0.0.1:5500"));
//app.UseCors("MyJSPolicy");

app.MapControllers();

app.Run();
