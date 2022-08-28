using API.Configurations;
using API.Configurations.CustomMiddleware;
using API.Helpers;
using API.services;
using Application;
using Application.Configurations;
using Application.ServiceInterfaces;
using Application.ServiceInterfaces.IUserServices;
using Infrastructure;
using PVerify;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
var swaggerOptions = builder.Configuration.GetSection(SwaggerOptions.key).Get<SwaggerOptions>();

builder.Services
    .AddSwagger(swaggerOptions)
    .AddCORS()
    .AddServices(builder.Configuration)
    .AddFluentValidation()
    .AddRepository(builder.Configuration)
    .AddEligiblityAPIDependency(builder.Configuration)
    .AddControllers();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
// configure strongly typed settings object
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("CacheSettings"));
builder.Services.Configure<PVerifyApiSettings>(builder.Configuration.GetSection("PVerifyApiSettings"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles("/swaggerui/theme-material.css");
app.UseCors("EnableCorsForntendProject");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerOptions.APIName);
    c.RoutePrefix = string.Empty;
    c.DocExpansion(DocExpansion.List);
    c.DocumentTitle = swaggerOptions.APIName;
    c.InjectStylesheet("/swaggerui/theme-material.css");
});

app.UseHttpsRedirection();
//app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();