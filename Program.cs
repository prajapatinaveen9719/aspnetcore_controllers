var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();



app.MapGet("/", () => "Welcome to the Best Bank !");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id:int?}"
    );

app.Run();
