using CallLogging.Data;
using CallLogging.Data.ConferenceRepo;
using CallLogging.Data.ContactRepo;
using CallLogging.Data.PhoneCallRepo;
using CallLogging.Data.PhoneNumberRepo;
using CallLogging.Services.ConferenceService;
using CallLogging.Services.ContactService;
using CallLogging.Services.PhoneCallService;
using CallLogging.Services.PhoneNumberService;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("CallLoggingConnection")));

// Add services to the container. Add JSON Serializer.
// TODO: I should think about AddControllers and CamelCasePropertyNamesContractResolver
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

// Injected repositories
builder.Services.AddScoped<IContactRepo, ContactRepo>();
builder.Services.AddScoped<IConferenceRepo, ConferenceRepo>();
builder.Services.AddScoped<IPhoneCallRepo, PhoneCallRepo>();
builder.Services.AddScoped<IPhoneNumberRepo, PhoneNumberRepo>();

// Injected services
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IConferenceService, ConferenceService>();
builder.Services.AddScoped<IPhoneCallService, PhoneCallService>();
builder.Services.AddScoped<IPhoneNumberService, PhoneNumberService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
