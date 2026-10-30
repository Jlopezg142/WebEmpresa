//using Microsoft.EntityFrameworkCore;
using WebEmpresa.Components;
//using WebEmpresa.Data;

var builder = WebApplication.CreateBuilder(args);


// ======================================================
// BLAZOR
// ======================================================

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();


// ======================================================
// API CONTROLLERS
// ======================================================

builder.Services.AddControllers();


// ======================================================
// MYSQL / ENTITY FRAMEWORK
// ======================================================

//var connectionString =
//   builder.Configuration.GetConnectionString("ConexionMySql")
//    ?? throw new InvalidOperationException(
//        "No se encontró la cadena de conexión ConexionMySql."
//    );
//
//builder.Services.AddDbContext<Conexiones>(options =>
//{
//    options.UseMySql(
//        connectionString,
//        ServerVersion.AutoDetect(connectionString)
//    );
//});


// ======================================================
// HTTP CLIENT
// Cliente.razor consume la API del mismo proyecto
// ======================================================

builder.Services.AddHttpClient(
    "ApiEmpresa",
    client =>
    {
        client.BaseAddress =
            //new Uri("http://localhost:5238/");
            //new Uri("http://localhost:5222/");
            new Uri("https://apiempresa-docker-jlopez.azurewebsites.net/");}
);


var app = builder.Build();


// ======================================================
// PIPELINE
// ======================================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(
        "/Error",
        createScopeForErrors: true
    );

    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute(
    "/not-found",
    createScopeForStatusCodePages: true
);


// Estamos trabajando en HTTP local.
// Evitamos por ahora la advertencia de redirección HTTPS.
//
// app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseAntiforgery();

app.MapStaticAssets();


// ======================================================
// ENDPOINTS DEL API
// ======================================================

app.MapControllers();


// ======================================================
// BLAZOR
// ======================================================

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();