var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.Use(async (context, next) =>
{
    if (context.Request.Path.ToString().Contains("/end"))
    {
        await context.Response.WriteAsync("Terminated chain because URL contains /end");
    }
    else
    {
        await next.Invoke();
    }
});

// Middleware 2: Display 'hello1' and 'hello2'
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello1\n");
    await next.Invoke();
    await context.Response.WriteAsync("Hello2\n");
});

// Middleware 3: Display 'hello' if URL contains 'hello'
app.Use(async (context, next) =>
{
    if (context.Request.Path.ToString().Contains("/hello"))
    {
        await context.Response.WriteAsync("Hello\n");
    }
    await next.Invoke();
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=First}/{action=Index}/{id?}");

app.Run();
