using mvc;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Agrega el soporte para MySQL
builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("DataContext")!);

// Agrega la funcionalidad de MVC
builder.Services.AddControllersWithViews();

// Soporte para consultar los datos
builder.Services.AddScoped<IDataContext, DataContext>();

// Construye la aplicación web
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // En caso de error en producción, oculta los errores y manda a una página personalizada
    app.UseExceptionHandler("/Home/Error");
    // Establece que la aplicación debe ejecutarse en HTTPS
    app.UseHsts();
}

// Utiliza rutas para los endpoints de los controladores
app.UseRouting();

// Establece el patrón de rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

