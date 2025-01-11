using System.Data.SqlClient;
using System.Text;
using HttpServerLibrary;
using Models;
using MyHtttpServer.Core.Templator;
using MyORMLibrary;

namespace MyHtttpServer.Endponts;

public class DashboardEndpoint : BaseEndpoint
{
    [Get("")]
    public IHttpResponseResult GetPage()
    {
        return Redirect("dashboard");
    }
    
    [Get("dashboard")]
    public IHttpResponseResult GetDashboard()
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
}