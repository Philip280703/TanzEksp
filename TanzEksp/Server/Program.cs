using Microsoft.AspNetCore.ResponseCompression;
using TanzEksp.Infrastructure.Persistence.EFContext;
using TanzEksp.Server.ServerIOC;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TanzEksp.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TanzEksp.Application.Interfaces;
using TanzEksp.Infrastructure.Persistence.Repositories;
using TanzEksp.Application.UseCases;
using System.Globalization;
using Swashbuckle.AspNetCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddServerServices(); // Register IOC service her


builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Seed roles and admin
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string[] roles = new[] { "Admin", "User"};
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    var config = builder.Configuration;

    var admin = await userManager.FindByNameAsync(config["AdminUser:UserName"]);
    if (admin == null)
    {
        var adminUser = new ApplicationUser
        {
            UserName = config["AdminUser:UserName"],
            Email = config["AdminUser:Email"],
            FullName = config["AdminUser:FullName"]
        };

        var result = await userManager.CreateAsync(adminUser, config["AdminUser:Password"]);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TanzEksp API v1");
        c.RoutePrefix = "swagger"; // så det ligger på /swagger
    });

    app.UseWebAssemblyDebugging();
}


app.UseRouting();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();



app.UseBlazorFrameworkFiles();
app.UseStaticFiles();



app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
