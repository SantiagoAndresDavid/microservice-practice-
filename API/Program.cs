using API.Context;
using API.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAppDBContext, AppDBContext>();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(context => context.UseSqlServer("Server=172.19.0.2,1433;Database=API;user id=sa;password=<YourStrong@Passw0rd>;Persist Security Info=False;Encrypt=False;TrustServerCertificate=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Disable HTTPS Redirection in Development
    // Comment or remove this line to disable HTTPS redirection
    // app.UseHttpsRedirection(); 
}
else
{
    app.UseHttpsRedirection(); // Only use HTTPS redirection in Production
}

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
var scope = app.Services.CreateScope();
await Migrations(scope.ServiceProvider);

app.Run();


async Task Migrations(IServiceProvider serviceProvider)
{
    var context = serviceProvider.GetService<AppDBContext>();
    var connAppDb = context!.Database.GetDbConnection();

    Console.WriteLine($"Conexión Actual AppDB: {connAppDb.ToString()}  {Environment.NewLine}  {connAppDb.ConnectionString}");
    Console.WriteLine("****************** Probando acceso  *******************");
    
    try
    {
        Console.WriteLine("Base Disponible de API:" + context.Database.CanConnect());
        context.Database.Migrate();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"------ !!! ERROR connectando: {ex.Message}");
    }
}
