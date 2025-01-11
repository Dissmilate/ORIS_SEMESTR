using Models;
using MyHtttpServer.Core.Templator;
using TemplateEngineUnitTests.Models;

namespace MyHttpServer.UnitTests.Core.Templator
{
    [TestClass]
    public class CustomTemplatorTests
    {

        [TestMethod]
        public void GetHtmlByTemplate_When_NameIsnotNull_ResultSuccess()
        {
            ICustomTemplator customTemplator = new CustomTemplator();
            string template = "<label>name</label><p>{name}</p>";
            string name = "QWE";

            var result = customTemplator.GetHtmlByTemplate(template, name);

            Assert.AreEqual("<label>name</label><p>QWE</p>", result);
        }
        
        [TestMethod]
        public void FillIndexTemplate_When_MovieIsProvided_ReplacePlaceholdersWithMovieDetails()
        {
            var movie = new Movie()
            {
                MovieId = 123,
                Title = "Inception",
                PosterUrl = "http://example.com/inception.jpg",
                Quality = "HD",
                ReleaseDate = "2010-07-16",
                Country = "USA",
                Genre = "Sci-Fi"
            };

            string result = CustomTemplator.FillIndexTemplate(movie);

            Assert.IsTrue(result.Contains("href='Template/Pages/FilmPage/123'"));
            Assert.IsTrue(result.Contains("src=\"http://example.com/inception.jpg\""));
            Assert.IsTrue(result.Contains("Смотреть Inception онлайн в HD качестве HD"));
            Assert.IsTrue(result.Contains("2010-07-16, USA, Sci-Fi"));
        }

        
        
        [TestMethod]
        public void GetHtmlByTemplate_When_ObjectHasProperties_ReplacePlaceholdersSuccessfully()
        {
            ICustomTemplator customTemplator = new CustomTemplator();
            string template = "<label>Title:</label><p>{Title}</p><label>Release Date:</label><p>{ReleaseDate}</p>";
            var movie = new Movie
            {
                Title = "Inception",
                ReleaseDate = "2010-07-16"
            };

            var result = customTemplator.GetHtmlByTemplate(template, movie);

            Assert.AreEqual("<label>Title:</label><p>{Title}</p><label>Release Date:</label><p>{ReleaseDate}</p>", result);
        }
    }
}
