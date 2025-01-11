using HttpServerLibrary;
using Models;
using MyHtttpServer.Core.Templator;
using MyHtttpServer.Session;
using MyORMLibrary;
using System.Data.SqlClient;
using System.Text;

namespace MyHtttpServer.Endponts
{
    public class MoviesEndpoint : BaseEndpoint
    {
        [Get("AllMovies")]
        public IHttpResponseResult GetAllMovies() 
        {
                var file = File.ReadAllText(@"public/index.html");
                string connectionString =
                    @"Server=localhost; Database=usersdb; User Id=sa; Password=P@ssw0rd;TrustServerCertificate=true;";
                var connection = new SqlConnection(connectionString);
                var dBcontext = new ORMContext<Movie>(connection);
                var movies = dBcontext.GetAll();
                StringBuilder sb = new StringBuilder();
                foreach (var movie in movies)
                {
                    sb.Append(CustomTemplator.FillIndexTemplate(movie));
                }
                file = file.Replace("@@MOVIES@@", sb.ToString());
                return Html(file);
        }
        
        [Get("AllSeries")]
        public IHttpResponseResult GetAllSeries() 
        {
            var file = File.ReadAllText(@"public/index.html");
            string connectionString =
                @"Server=localhost; Database=usersdb; User Id=sa; Password=P@ssw0rd;TrustServerCertificate=true;";
            var connection = new SqlConnection(connectionString);
            var dBcontext = new ORMContext<Movie>(connection);
            var movies = dBcontext.GetAllOfType("Сериал");
            StringBuilder sb = new StringBuilder();
            foreach (var movie in movies)
            {
                sb.Append(CustomTemplator.FillIndexTemplate(movie));
            }
            file = file.Replace("@@MOVIES@@", sb.ToString());
            return Html(file);
        }
        
        [Get("AllFilms")]
        public IHttpResponseResult GetAllFilms() 
        {
            var file = File.ReadAllText(@"public/index.html");
            string connectionString =
                @"Server=localhost; Database=usersdb; User Id=sa; Password=P@ssw0rd;TrustServerCertificate=true;";
            var connection = new SqlConnection(connectionString);
            var dBcontext = new ORMContext<Movie>(connection);
            var movies = dBcontext.GetAllOfType("Фильм");
            StringBuilder sb = new StringBuilder();
            foreach (var movie in movies)
            {
                sb.Append(CustomTemplator.FillIndexTemplate(movie));
            }
            file = file.Replace("@@MOVIES@@", sb.ToString());
            return Html(file);
        }
        
        [Get("AllAnime")]
        public IHttpResponseResult GetAllAnime() 
        {
            var file = File.ReadAllText(@"public/index.html");
            string connectionString =
                @"Server=localhost; Database=usersdb; User Id=sa; Password=P@ssw0rd;TrustServerCertificate=true;";
            var connection = new SqlConnection(connectionString);
            var dBcontext = new ORMContext<Movie>(connection);
            var movies = dBcontext.GetAllOfType("Аниме");
            StringBuilder sb = new StringBuilder();
            foreach (var movie in movies)
            {
                sb.Append(CustomTemplator.FillIndexTemplate(movie));
            }
            file = file.Replace("@@MOVIES@@", sb.ToString());
            return Html(file);
        }
        
        [Get("AllCartoons")]
        public IHttpResponseResult GetAllCartoons() 
        {
            var file = File.ReadAllText(@"public/index.html");
            string connectionString =
                @"Server=localhost; Database=usersdb; User Id=sa; Password=P@ssw0rd;TrustServerCertificate=true;";
            var connection = new SqlConnection(connectionString);
            var dBcontext = new ORMContext<Movie>(connection);
            var movies = dBcontext.GetAllOfType("Мультфильм");
            StringBuilder sb = new StringBuilder();
            foreach (var movie in movies)
            {
                sb.Append(CustomTemplator.FillIndexTemplate(movie));
            }
            file = file.Replace("@@MOVIES@@", sb.ToString());
            return Html(file);
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
