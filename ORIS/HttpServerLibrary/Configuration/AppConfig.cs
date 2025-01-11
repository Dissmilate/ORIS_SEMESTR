using System.Text.Json;

namespace HttpServerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AppConfig
    {
        /// <summary>
        /// Получаем и задаем Домен
        /// </summary>
        public static string Domain { get; set; } = "localhost";

        /// <summary>
        /// Получаем и задаем порт
        /// </summary>
        public static uint Port { get; set; } = 1337;

        /// <summary>
        /// Получаем и задаем путь к нашим сайтам
        /// </summary>
        public static string StaticDirectoryPath { get; set; } = @"public\";

        /// <summary>
        /// Метод чтения данных из файла JSON
        /// </summary>
        /// <param name="config">Данные конфигурации JSON</param>
        /// <returns>Восстанавливается в исходную структуру данных</returns>
        public async Task ReadJSONFile(AppConfig config = null)
        {
            if (File.Exists("config.json"))
            {
                var fileConfig = await File.ReadAllTextAsync("config.json");
                config = JsonSerializer.Deserialize<AppConfig>(fileConfig);
            }
            else
            {
                Console.WriteLine("файл конфигурации сервера 'config.json' не найден");
                config = new AppConfig();
            }
        }
    }
}
