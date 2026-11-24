using DBrownWebApp.Data.DAL;
using DBrownWebApp.Data.Strategies;

namespace DBrownWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<IMovieDal>(MovieDal.Instance);


            builder.Services.AddTransient<IMovieSortStrategy, SortByTitleStrategy>();
            builder.Services.AddTransient<IMovieSortStrategy, SortByYearStrategy>();
            builder.Services.AddTransient<IMovieSortStrategy, SortByScoreStrategy>();
            builder.Services.AddTransient<MovieSortContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}