using Models;
using MyHtttpServer.Core.Templator;
using System.Text.RegularExpressions;
using MyHtttpServer.Core.Templator;

namespace MyHtttpServer.Core.Templator
{
    public class CustomTemplator : ICustomTemplator
    {
        public string GetHtmlByTemplate(string template, string name)
        {
            return template.Replace("{name}", name);
        }

        public string GetHtmlByTemplate<T>(string template, T obj)
        {
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var placeholder = $"{{{{{property.Name}}}}}";
                template = template.Replace(placeholder, property.GetValue(obj)?.ToString(), StringComparison.OrdinalIgnoreCase);
            }
            return template;
        }

        public static string FillIndexTemplate(Movie movie)
        {
            var template = $@"<div class=""b-content__inline_item"" data-id=""76764"" data-url=""https://hdrezka.rest/films/detective/76764-karibskaya-tayna-1983.html"">
                                    <div class=""b-content__inline_item-cover"">
                                           <a href='/watch?movieId={movie.MovieId}'>
                                            <img src=""{movie.PosterUrl}"" height=""250"" width=""166"" alt=""Смотреть {movie.Title} онлайн в HD качестве {movie.Quality}""/>
                                           
                                            <i class=""i-sprt play""></i>
                                        </a>
                                        <i class=""trailer show-trailer"" data-id=""76764"" data-full=""1"">
                                            <b>Смотреть трейлер</b>
                                        </i>
                                    </div>
                                    <div class=""b-content__inline_item-link"">
                                        <a href="""">{movie.Title}</a>
                                        <div>{movie.ReleaseDate}, {movie.Country}, {movie.Genre}</div>
                                        <!-- <div> <span class=""b-content__inline_item-prem-label"">Дубляж&nbsp;<img src=""https://static.hdrezka.ac/templates/hdrezka/images/ua-flag.png"" alt="""" height=""8px""></span> </div> -->
                                    </div>
                                </div>";
            return template;
        }

        public static string FillFilmPageTemplate(Movie movie, string htmlTemplate)
        {
            var filledTemplate = htmlTemplate.Replace("@@PosterUrl@@", movie.PosterUrl)
                .Replace("@@Title@@", movie.Title)
                .Replace("@@Country@@", movie.Country)
                .Replace("@@ImdbRating@@", movie.IMdbRating.ToString())
                .Replace("@@ImdbVotes@@", movie.ImdbVotes.ToString())
                .Replace("@@Description@@", movie.Description)
                .Replace("@@ReleaseDate@@", movie.ReleaseDate)
                .Replace("@@Country@@", movie.Country)
                .Replace("@@Director@@", movie.Director)
                .Replace("@@Genre@@", movie.Genre)
                .Replace("@@Quality@@", movie.Quality)
                .Replace("@@AgeRating@@", movie.AgeRating)
                .Replace("@@Duration@@", movie.Duration.ToString())
                .Replace("@@PosterUrl@@", movie.PosterUrl);
            return filledTemplate;
        }
        
        
    }
}
