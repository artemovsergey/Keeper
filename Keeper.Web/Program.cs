namespace Keeper.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        string connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<KeeperContext>(options => options.UseSqlServer(connection));
        
        //builder.Services.AddScoped<StatementViewModel>();
        //builder.Services.AddServerSideBlazor();

        //builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseBlazorFrameworkFiles();

        app.UseRouting();

        //app.MapBlazorHub();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
