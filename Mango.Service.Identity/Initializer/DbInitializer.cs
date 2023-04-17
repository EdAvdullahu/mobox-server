using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Mobox.Service.Identity.Models;
using Mobox.Services.Identity.DbContexts;
using System.Security.Claims;

namespace Mobox.Service.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _db = db;
            _userManager = userManager; 
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Artist)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "Ben",
                LastName = "Admin"
            };

            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName + " "+ adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName ),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, SD.Admin)
            }).Result;


            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer1@gmail.com",
                Email = "customer1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "Ben",
                LastName = "Cust"
            };

            _userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, customerUser.FirstName + " "+ customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName, customerUser.FirstName ),
                new Claim(JwtClaimTypes.FamilyName, customerUser.LastName),
                new Claim(JwtClaimTypes.Role, SD.Customer)
            }).Result;

            ApplicationUser ArtistUser = new ApplicationUser()
            {
                UserName = "artist1@gmail.com",
                Email = "artist1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "Ben",
                LastName = "Artist"
            };

            _userManager.CreateAsync(ArtistUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(ArtistUser, SD.Artist).GetAwaiter().GetResult();

            var temp3 = _userManager.AddClaimsAsync(ArtistUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, ArtistUser.FirstName + " "+ ArtistUser.LastName),
                new Claim(JwtClaimTypes.GivenName, ArtistUser.FirstName ),
                new Claim(JwtClaimTypes.FamilyName, ArtistUser.LastName),
                new Claim(JwtClaimTypes.Role, SD.Artist)
            }).Result;
        }

        
    }
}
