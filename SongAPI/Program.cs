using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SongAPI;
using SongAPI.DbContexts;
using SongAPI.RabbitMq.Consumer;
using SongAPI.Repository;
using SongAPI.Repository.Interface;
using SongAPI.Services;
using SongAPI.Services.Interface;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
IMapper mapper = MappingConfig.RegisterMap().CreateMapper();
builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// DI
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<ISongGenreRepository, SongGenreRepository>();
builder.Services.AddScoped<IReleaseRepository, ReleaseRepository>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IAudioService, AudioService>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStreamRepository, StreamRepository>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();
builder.Services.AddScoped<ISongStatistics, SongStatistics>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<IReleaseStatistics, ReleaseStatistics>();
builder.Services.AddScoped<IUserStatistics, UserStatistics>();
builder.Services.AddHostedService<RabbitMqConsumer>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(option =>
{
    option.CacheProfiles.Add("Default30",
       new CacheProfile()
       {
           Duration = 30
       });
    //option.ReturnHttpNotAcceptable=true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateTokenReplay = true
        };
    });

var app = builder.Build();

/*Test testS = new Test();
await testS.TestService();*/


app.UseCors(options =>
options.WithOrigins("http://localhost:3000")
.AllowAnyMethod()
.AllowAnyHeader());

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