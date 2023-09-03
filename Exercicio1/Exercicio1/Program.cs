using Exercicio1.Data; // Importa el espacio de nombres Exercicio1.Data

var builder = WebApplication.CreateBuilder(args);

// Configura servicios y dependencias.

builder.Services.AddControllers(); // Agrega controladores a los servicios
builder.Services.AddEndpointsApiExplorer(); // Agrega la exploraci�n de API de puntos finales
builder.Services.AddSwaggerGen(); // Agrega Swagger para generar documentaci�n de la API

// Configura la base de datos
builder.Services.AddDbContext<AppDbContext>(); // Agrega el contexto de la base de datos

var app = builder.Build();

// Configura el flujo de solicitud HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita el middleware de Swagger
    app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS

app.UseAuthorization(); // Habilita la autorizaci�n

app.MapControllers(); // Mapea los controladores de la API

app.Run(); // Inicia la aplicaci�n
