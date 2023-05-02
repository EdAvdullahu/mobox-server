using Microsoft.AspNetCore.Authentication.Cookies;
using Web.Services.IServices;
using Web.Services;
using Microsoft.Extensions.Options;
using Web;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


builder.Services.AddDistributedMemoryCache();

builder.Services.AddControllersWithViews();
//services.AddAuthentication(options =>
//{
//    options.DefaultScheme = "Cookies";
//    options.DefaultChallengeScheme = "oidc";
//})
//                .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
//                .AddOpenIdConnect("oidc", options =>
//                {
//                    options.Authority = Configuration["ServiceUrls:IdentityAPI"];
//                    options.GetClaimsFromUserInfoEndpoint = true;
//                    options.ClientId = "mango";
//                    options.ClientSecret = "secret";
//                    options.ResponseType = "code";
//                    options.ClaimActions.MapJsonKey("role", "role", "role");
//                    options.ClaimActions.MapJsonKey("sub", "sub", "sub");
//                    options.TokenValidationParameters.NameClaimType = "name";
//                    options.TokenValidationParameters.RoleClaimType = "role";
//                    options.Scope.Add("mango");
//                    options.SaveTokens = true;

//                });

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
                .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = builder.Configuration["ServiceUrls:IdentityAPI"];
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClientId = "mobox";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.TokenValidationParameters.NameClaimType = "name";
                    options.TokenValidationParameters.RoleClaimType = "role";
                    options.Scope.Add("mobox");
                    options.SaveTokens = true;

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
