using MediatR;
using MyApp.Application.Orders.Queries.GetAllOrders;
using MyApp.Application.Orders.Queries.GetOrdersById;
using MyApp.Infrastructure.DataAccess.OrderRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using MyApp.Domain.Models;

// Create the web application builder
var builder = WebApplication.CreateBuilder(args);

// Configure services for dependency injection
// Add API Explorer for Swagger/OpenAPI documentation
builder.Services.AddEndpointsApiExplorer();

// Configure JWT authentication settings from appsettings.json
var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
var keyBytes = Encoding.UTF8.GetBytes(jwtConfig.Key);
// Configure Swagger/OpenAPI documentation with JWT Bearer authentication
builder.Services.AddSwaggerGen(c =>
{
    // Set basic API information
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Configure JWT Bearer token authentication in Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] + token.  
Example: 'Bearer eyJhbGciOi...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Add security requirement for all endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

// Register core services
builder.Services.AddControllers(); // Add MVC controllers support

// Register repository pattern dependencies
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Register MediatR for CQRS pattern implementation
// Note: Both registrations point to the same assembly but are kept for clarity
builder.Services.AddMediatR(typeof(GetAllOrdersHandler).Assembly);
builder.Services.AddMediatR(typeof(GetOrdersByIdHandler).Assembly);
// Configure JWT Bearer Authentication
builder.Services.AddAuthentication(options =>
{
    // Set JWT Bearer as the default authentication scheme
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Configure JWT token validation parameters
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,           // Validate the token issuer
        ValidateAudience = true,         // Validate the token audience
        ValidateLifetime = true,         // Validate token expiration
        ValidateIssuerSigningKey = true, // Validate the signing key
        ValidIssuer = jwtConfig.Issuer,
        ValidAudience = jwtConfig.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
    };
});
// Configure Authorization policies
builder.Services.AddAuthorization(options =>
{
    // Define a Bearer policy that requires authentication and specific scope claim
    options.AddPolicy("Bearer", policy =>
    {
        policy.RequireAuthenticatedUser();           // User must be authenticated
        policy.RequireClaim("scope", "api.read");    // User must have 'api.read' scope
    });
});

// Build the application
var app = builder.Build();

// Configure middleware pipeline
// Add authentication and authorization middleware (order matters!)
app.UseAuthentication(); // Must come before UseAuthorization
app.UseAuthorization();

// Configure the HTTP request pipeline for development environment
if (app.Environment.IsDevelopment())
{
    // Enable Swagger documentation and UI only in development
    app.UseSwagger();      // Enable Swagger JSON endpoint
    app.UseSwaggerUI();    // Enable Swagger UI for testing APIs
}

// Map controller routes to handle HTTP requests
app.MapControllers();

// Start the application
app.Run();

/// <summary>
/// Configuration class for JWT authentication settings
/// Maps to the "JwtConfig" section in appsettings.json
/// </summary>
public class JwtConfig
{
    /// <summary>
    /// Gets or sets the JWT token issuer
    /// </summary>
    public string Issuer { get; set; }
    
    /// <summary>
    /// Gets or sets the JWT token audience
    /// </summary>
    public string Audience { get; set; }
    
    /// <summary>
    /// Gets or sets the secret key used for token signing and validation
    /// </summary>
    public string Key { get; set; }
    
    /// <summary>
    /// Gets or sets the token expiration time in minutes
    /// </summary>
    public int ExpiryMinutes { get; set; }
}