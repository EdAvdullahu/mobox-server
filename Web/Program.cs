using Microsoft.AspNetCore.Authentication.Cookies;
using Web.Services.IServices;
using Web.Services;
using Microsoft.Extensions.Options;
using Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

SD.SongApiBase = builder.Configuration["ServiceUrls:SongAPI"];
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpClient<IArtistService, ArtistService>();
builder.Services.AddScoped<IArtistService, ArtistService>();

builder.Services.AddHttpClient<IFeatureService, FeatureService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();

builder.Services.AddHttpClient<IGenreService, GenreService>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddHttpClient<IReleaseService, ReleaseService>();
builder.Services.AddScoped<IReleaseService, ReleaseService>();

builder.Services.AddHttpClient<ISongGenreService, SongGenreService>();
builder.Services.AddScoped<ISongGenreService, SongGenreService>();

builder.Services.AddHttpClient<ISongService, SongService>();
builder.Services.AddScoped<ISongService, SongService>();

builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication
    (options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "oidc";
    })
              .AddCookie(options =>
              {
                  options.Cookie.HttpOnly = true;
                  options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                  options.LoginPath = "/Auth/Login";
                  options.AccessDeniedPath = "/Auth/AccessDenied";
                  options.SlidingExpiration = true;
              })
              .AddOpenIdConnect("oidc", options =>
              {
                  /*options.Authority = builder.Configuration["ServiceUrls:IdentityAPI"];*/
                  options.Authority = "https://localhost:7006";
                  options.GetClaimsFromUserInfoEndpoint = true;
                  options.ClientId = "mobox";
                  options.ClientSecret = "secret";
                  options.ResponseType = "code";

                  options.TokenValidationParameters.NameClaimType = "name";
                  options.TokenValidationParameters.RoleClaimType = "role";
                  options.Scope.Add("mobox");
                  options.SaveTokens = true;
              });
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
