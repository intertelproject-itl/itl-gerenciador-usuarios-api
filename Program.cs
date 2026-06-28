using itl_gerenciador_usuarios_api.Infraestructure;
using itl_gerenciador_usuarios_api.Infraestructure.Integration;
using itl_gerenciador_usuarios_api.Infraestructure.NoSql;
using itl_gerenciador_usuarios_api.Infraestructure.Repositories;
using itl_gerenciador_usuarios_api.Services;
using itl_gerenciador_usuarios_api.Services.v1.Encrypt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var ptBr = new CultureInfo("pt-BR");
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { ptBr };

    options.DefaultRequestCulture = new RequestCulture(ptBr);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Clear();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaPoliticaCors", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIntegrationModule();
builder.Services.AddRepositoriesModule();
builder.Services.AddApplictionModule();

var mongoConn = builder.Configuration.GetConnectionString("MongoDB");
builder.Services.AddSingleton<MongoDB.Driver.IMongoClient>(sp => new MongoDB.Driver.MongoClient(mongoConn));
builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

// Discord integration
builder.Services.Configure<DiscordSettings>(builder.Configuration.GetSection("Integrations:Discord"));
builder.Services.AddHttpClient<DiscordIntegrationWrapper>();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(cs);
});
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwt = builder.Configuration.GetSection("Jwt");
        var key = jwt["Key"]!;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),

            ClockSkew = TimeSpan.FromSeconds(30) // tolerância pequena
        };
    });
builder.Services.AddSingleton<JwtTokenService>();
builder.Services.AddAuthorization();

var app = builder.Build();
Console.WriteLine($"ContentRootPath: {app.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {app.Environment.WebRootPath}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors("MinhaPoliticaCors");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
