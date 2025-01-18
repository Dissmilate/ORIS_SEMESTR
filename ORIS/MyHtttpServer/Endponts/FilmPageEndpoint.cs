using HttpServerLibrary;
using Models;
using MyHtttpServer.Core.Templator;
using MyHtttpServer.Session;
using MyORMLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyHtttpServer.Endponts
{
    public class FilmPageEndpoint : BaseEndpoint
    {
        [Get($"watch")]
        public IHttpResponseResult GetFilmPage(int movieId)
        {
            if (IsAuthorized(Context))
            {
                var file = File.ReadAllText(@"public/FilmPage.html");
                Movie movieInfo = new Movie();
                string connectionString =
                    @"Data Source=localhost;Initial Catalog=usersdb;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=true;";

                string query = "SELECT * FROM Movies WHERE MovieId = @MovieId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", movieId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows && IsAuthorized(Context))
                            {
                                while (reader.Read())
                                {
                                    movieInfo.MovieId = reader.GetInt32(0);
                                    movieInfo.Title = reader.GetString(1);
                                    movieInfo.Description = reader.GetString(2);
                                    movieInfo.IMdbRating = reader.GetDecimal(3);
                                    movieInfo.ImdbVotes = reader.GetInt32(4);
                                    movieInfo.ReleaseDate = reader.GetString(5);
                                    movieInfo.Country = reader.GetString(6);
                                    movieInfo.Director = reader.GetString(7);
                                    movieInfo.Genre = reader.GetString(8);
                                    movieInfo.Quality = reader.GetString(9);
                                    movieInfo.AgeRating = reader.GetString(10);
                                    movieInfo.Duration = reader.GetInt32(11);
                                    movieInfo.PosterUrl = reader.GetString(12);
                                }
                            }
                            else
                            {
                                return Redirect("dashboard");
                            }
                        }
                    }

                    var result = CustomTemplator.FillFilmPageTemplate(movieInfo, file);
                    return Html(result);
                }
            }
            return Redirect("login");
    }

    public bool IsAuthorized(HttpRequestContext context) 
    { 
        if (context.Request.Cookies.Any(c => c.Name == "session-token")) 
        { 
            var cookie = context.Request.Cookies["session-token"]; 
            return SessionStorage.ValidateToken(cookie.Value);
        } 
        return false;
    }    
    }
}
