using Microsoft.Extensions.Configuration;

namespace AgendadorOperaCloud
{
    public static class Program
    {
        public static IConfiguration? _Configuration;
        public static string? connectionstring { get; set; }
        public static string? idEdit { get; set; }

        [STAThread]
        static void Main()
        {
            var Builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            _Configuration = Builder.Build();

            ApplicationConfiguration.Initialize();
            Application.Run(new Agendador());
        }
    }
}