using System.Text.Json;
using XPRTZ.BingeMachine.Shows.TvMaze.Infrastructure;


namespace XPRTZ.BingeMachine.Shows.DeserializerTests
{
    [TestClass]
    public class ShowsDesializerTests
    {
        [TestMethod]
        public void Deserialize_TvMazeShowResponse_ReturnsExpectedValues()
        {
            var jsonShow = """
                           {"id":1,"url":"https://www.tvmaze.com/shows/1/under-the-dome","name":"Under the Dome","type":"Scripted","language":"English","genres":["Drama","Thriller"],"status":"Ended","runtime":60,"averageRuntime":60,"premiered":"2013-06-24","ended":"2015-09-10","officialSite":"http://www.cbs.com/shows/under-the-dome/","schedule":{"time":"22:00","days":["Thursday"]},"rating":{"average":6.5},"weight":96,"network":{"id":2,"name":"CBS","country":{"name":"United States","code":"US","timezone":"America/New_York"},"officialSite":"https://www.cbs.com/"},"webChannel":null,"dvdCountry":null,"externals":{"tvrage":25988,"thetvdb":264492,"imdb":"tt1553656"},"image":{"medium":"https://static.tvmaze.com/uploads/images/medium_portrait/81/202627.jpg","original":"https://static.tvmaze.com/uploads/images/original_untouched/81/202627.jpg"},"summary":"<p><b>Under the Dome</b> is the story of a small town that is suddenly and inexplicably sealed off from the rest of the world by an enormous transparent dome. The town's inhabitants must deal with surviving the post-apocalyptic conditions while searching for answers about the dome, where it came from and if and when it will go away.</p>","updated":1631010933,"_links":{"self":{"href":"https://api.tvmaze.com/shows/1"},"previousepisode":{"href":"https://api.tvmaze.com/episodes/185054"}}}

                           """;
            var show = JsonSerializer.Deserialize<Show>(jsonShow);
            Assert.AreEqual(1, show.Id);
            Assert.AreEqual("Under the Dome", show.Name);
            Assert.AreEqual("English", show.Language);
            Assert.AreEqual("Drama", show.Genres.First());
            Assert.AreEqual("Thriller", show.Genres.Last());
        }

        [TestMethod]
        public void Deserialize_TvMazeShowResponse_ReturnsDateTimeForPremiered()
        {
            var dummyData = new DummyData();
            Assert.IsTrue(dummyData.Shows.Any());
            Assert.IsTrue(dummyData.Shows.First().Premiered.HasValue);
        }

        [TestMethod]
        public void Deserialize_TvMazeListShowResponse_ReturnsValues()
        {
            var dummyData = new DummyData();
            Assert.IsTrue(dummyData.Shows.Any());
            foreach (var show in dummyData.Shows)
            {
                Assert.IsTrue(show.Id > 0);
                Assert.IsTrue(!string.IsNullOrEmpty(show.Name));
                Assert.IsTrue(!string.IsNullOrEmpty(show.Language));
                Assert.IsTrue(show.Premiered.HasValue);
                Assert.IsTrue(show.Genres.Any());
            }
        }
    }
}