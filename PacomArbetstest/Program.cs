using PacomArbetstest.Components;
using PacomArbetstest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Lägg till DbContext och anslutningssträng
builder.Services.AddDbContext<PacomDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContextPool<PacomDbContext>(options => options.UseSqlServer("DefaultConnection", providerOptions => providerOptions.EnableRetryOnFailure()));


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddHttpClient("ServerAPI", client =>
{
    var baseAddress = builder.Configuration.GetValue<string>("BaseAddress");
    if (string.IsNullOrEmpty(baseAddress))
    {
        throw new InvalidOperationException("BaseAddress configuration is missing.");
    }
    client.BaseAddress = new Uri(baseAddress);
});

var app = builder.Build();

AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppContext.BaseDirectory, "App_Data"));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();

app.Run();
