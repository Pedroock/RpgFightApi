using RpgFight.Data;
using Microsoft.EntityFrameworkCore;
using RpgFight.Services.AuthService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using RpgFight.Services.DMService;
using RpgFight.Services.EffectService;
using RpgFight.Services.WardrobeService;
using RpgFight.Services.GuildService;
using RpgFight.Services.ArenaService;
using RpgFight.Services.HttpContextService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("DungeonMaster", policy => policy.RequireUserName("DungeonMaster"));
    });
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
        Description = "Auth header, use --> bearer {token}",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDMService, DMService>();
builder.Services.AddScoped<IEffectService, EffectService>();
builder.Services.AddScoped<IWardrobeService, WardobreService>();
builder.Services.AddScoped<IGuildService, GuildService>();
builder.Services.AddScoped<IArenaService, ArenaService>();
builder.Services.AddScoped<IHttpContextService, HttpContextService>();
builder.Services.AddHttpContextAccessor();

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
