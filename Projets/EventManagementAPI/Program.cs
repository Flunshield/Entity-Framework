using System.Reflection;
using EventManagementAPI.Data;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Repositories;
using EventManagementAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Services
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Event Management API", 
        Version = "v1",
        Description = "API pour la gestion d'événements professionnels",
        Contact = new OpenApiContact {
            Name = "BERTRAND Julien",
            Email = "j.bertrand.sin@gmail.com"
        }
    });
    
    // Ajouter des commentaires XML pour la documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Ajoutez CORS ici
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Optional: Register generic repository
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
// Add other specific repositories here (e.g., IEventRepository, IParticipantRepository...)

// Services métier
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<ISpeakerService, SpeakerService>();

// DB Context
builder.Services.AddDbContext<AppDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// 2. Middleware pipeline (ordre important)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // Exécuter les migrations en développement
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
}

// Gestion des exceptions (doit être au début du pipeline)
app.UseExceptionHandler(appError => {
    appError.Run(async context => {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new {
            context.Response.StatusCode,
            Message = "Une erreur interne s'est produite."
        });
    });
});

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();