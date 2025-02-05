using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FileManagerApp.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<FileManagerAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FileManagerAppContext") ?? throw new InvalidOperationException("Connection string 'FileManagerAppContext' not found.")));

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
