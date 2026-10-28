
using DotNetEnv;
using GameHubApi.Data;
using GameHubApi.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING")
    ?? throw new InvalidOperationException("Missing MONGODB_CONNECTION_STRING");

var databaseName =
    Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME")
    ?? throw new InvalidOperationException("Missing MONGODB_DATABASE_NAME");

var jwtSecret =
    Environment.GetEnvironmentVariable("JWTSECRET")
    ?? throw new InvalidOperationException("Missing JWTSECRET");

// Swagger + Bearer token support
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Paste your JWT access token here."
    });

    options.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer", document)] = []
        });
});

// JWT authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSecret))
        };
    });

builder.Services.AddAuthorization();

// MongoDB services
builder.Services.AddSingleton<IMongoClient>(
    _ => new MongoClient(connectionString));

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(databaseName);
});

builder.Services.AddSingleton<GameHubDbContext>();
builder.Services.AddSingleton<PasswordService>();
builder.Services.AddSingleton<JWTService>(_ => new JWTService(jwtSecret));

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

// Authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// API endpoints
app.MapControllers();

// MongoDB connection test
app.MapGet("/api/health/mongodb", async (IMongoDatabase database) =>
{
    try
    {
        var result = await database.RunCommandAsync<BsonDocument>(
            new BsonDocument("ping", 1));

        return Results.Ok(new
        {
            status = "Connected",
            database = database.DatabaseNamespace.DatabaseName,
            response = result["ok"].ToString()
        });
    }
    catch (Exception)
    {
        return Results.Problem(
            title: "MongoDB connection failed",
            statusCode: 503);
    }
});

app.Run();
