using System.Data.SqlClient;
using HttpServerLibrary;

namespace MyHtttpServer.Endponts
{
    public class AdminEndpoint : BaseEndpoint
    {
        [Get("admin")]
        public IHttpResponseResult GetAdmin() 
        {
            var file = File.ReadAllText(@"Templates/Pages/AdminPanel/Admin.html");
            return Html(file);
        }
        
        [Post("add")]
        public IHttpResponseResult Add(string title, string description, decimal imdbRating, int imdbVotes,
        string releaseDate, string country, string director,
        string genre, string quality, string ageRating, int duration, string posterUrl, int genreId, string type)
        {
            string connectionString =
                @"Data Source=localhost;Initial Catalog=usersdb;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=true;";
            string query = @"INSERT INTO Movies (Title, Description, IMdbRating, IMdbVotes, 
                            ReleaseDate, Country, Director, Genre, Quality, AgeRating, Duration, PosterUrl, GenreId, Type)
                            VALUES (@Title, @Description, @IMdbRating, @IMdbVotes,
                             @ReleaseDate, @Country, @Director, @Genre, @Quality, @AgeRating, @Duration, 
                             @PosterUrl, @GenreId, @Type)";
            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Создание команды SQL с параметрами
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавление параметров запроса
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@IMdbRating", imdbRating);
                        command.Parameters.AddWithValue("@IMdbVotes", imdbVotes);
                        command.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                        command.Parameters.AddWithValue("@Country", country);
                        command.Parameters.AddWithValue("@Director", director);
                        command.Parameters.AddWithValue("@Genre", genre);
                        command.Parameters.AddWithValue("@Quality", quality);
                        command.Parameters.AddWithValue("@AgeRating", ageRating);
                        command.Parameters.AddWithValue("@Duration", duration);
                        command.Parameters.AddWithValue("@PosterUrl", posterUrl);
                        command.Parameters.AddWithValue("@GenreId", genreId);
                        command.Parameters.AddWithValue("@Type", type);
                        command.ExecuteNonQuery();
                    }
                }
                return Redirect("admin");
            }
            catch (Exception ex)
            {
                return Html($"Ошибка при добавлении фильма: {ex.Message}");
            }
        }
        
        [Post("delete")]
        public IHttpResponseResult Delete(int id)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=usersdb;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=true;";
            string query = "DELETE FROM Movies WHERE MovieID = @MovieId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            return Html("Фильм не найден.");
                        }
                    }
                }
                return Redirect("admin");
            }
            catch (Exception ex)
            {
                
            }
            return Redirect("admin");}
    }
}