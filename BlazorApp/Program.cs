using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Blazored.LocalStorage;
using BlazorApp.Data;
using DataAccess.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Business.Repository.IRepository;
using Business.Repository;
using BlazorApp.Service.IService;
using BlazorApp.Service;
using Microsoft.AspNetCore.Identity;
using BlazorApp.Model;
using MudBlazor.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddHttpClient<IHotelAmenityRepository, HotelAmenityRepository>(client => client.BaseAddress = new Uri("https://localhost:7063/"));
//builder.Services.AddHttpClient<IHotelRoomRepository, HotelRoomRepository>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")));

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IHotelRoomRepository,HotelRoomRepository>();
builder.Services.AddScoped<IHotelRoomService, HotelRoomService>();
builder.Services.AddScoped<IHotelRoomImageService, HotelImageService>();
builder.Services.AddScoped<IHotelAmenityService, HotelAmenityService>();
builder.Services.AddScoped<IHotelRoomImagesRepository, HotelImagesRepository>();
builder.Services.AddScoped<IHotelAmenityRepository, HotelAmenityRepository>();
builder.Services.AddScoped<ICustomerBookingService, CustomerBookingService>();

builder.Services.AddScoped<TokenProvider>();
builder.Services.AddHttpClient("HAIDP", client =>
{
    client.BaseAddress = new Uri("https://psl-app-vm3/HotelAdminAPI/");
});

builder.Services.AddScoped<BlazorApp.Service.IService.IFileUpload, FileUpload>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();


//
builder.Services.AddAuthentication(options =>
{
   
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
        options =>
        {
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
            options.Authority = "https://psl-app-vm3/HotelAdminIDP";
            options.ClientId = "La_Villa_Hotel";
            options.ClientSecret = "511536EF-F270-4058-81CB-1C89C192F622";

            // When set to code, the middleware will use PKCE protection
            options.ResponseType = "code";

            // The "openid" and "profile" scopes are added automatically,
            // so we don't need to add them for this test
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("HotelAdminAPI");

            // Save the tokens we receive from the IDP
            options.SaveTokens = true;

            // It's recommended to always get claims from the 
            // UserInfoEndpoint during the flow. 
            options.GetClaimsFromUserInfoEndpoint = true;
        });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseHsts();
IdentityModelEventSource.ShowPII = true;


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});
//app.MapBlazorHub();
app.MapRazorPages();
//app.MapFallbackToPage("/_Host");

app.Run();
