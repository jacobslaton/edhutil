namespace Edhutil.Api
{
    public class Program
    {
        private readonly IConfiguration _config;

        public Program()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(path: "appsettings.json")
                .Build();
        }

        public static void Main(string[] args) => new Program().Run(args);

        public void Run(string[] args)
        {
            string connectionLocation = "Connections:DefaultConnection";
            WebApplicationBuilder? webBuilder = WebApplication
                .CreateBuilder(args);
            webBuilder.Services.AddControllers();
            webBuilder.Services.AddEndpointsApiExplorer();
            webBuilder.Services.AddSwaggerGen();
            webBuilder.Services.AddSingleton<Services.CardProvider>
            (
                new Services.CardProvider
                (
                    hostname: _config[$"{connectionLocation}:Host"] ?? string.Empty,
                    port: _config[$"{connectionLocation}:Port"] ?? string.Empty,
                    username: _config[$"{connectionLocation}:User"] ?? string.Empty,
                    password: _config[$"{connectionLocation}:Password"] ?? string.Empty,
                    database: _config[$"{connectionLocation}:Database"] ?? string.Empty
                )
            );

            WebApplication app = webBuilder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            //app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}

