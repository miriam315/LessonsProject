
namespace LessonsProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDataContext, DataContext>();//יוצר  מופע לכל בקשה
            builder.Services.AddSingleton<IDataContext, DataContext>();//יוצר מופע אחד לכל האפליקציה
           builder.Services.AddTransient<IDataContext, DataContext>();//יוצר מופע חדש בכל פעם שיהיה רשום את הדרישה למופע

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
