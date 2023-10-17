using System.Net;
using System.Net.Http.Json;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.FunctionalTests.Shared;
using XPRTZ.BingeMachine.Test.Shared;

namespace XPRTZ.BingeMachine.Shows.FunctionalTests
{
    [TestClass]
    public class CreateShowScenarios
    {
        private HttpClient _client;
        private CustomWebApplicationFactory _factory;

        [TestInitialize]
        public void Initialize()
        {
            _factory = new CustomWebApplicationFactory(builder => { builder.RegisterModule(new TestModule()); });
            _client = _factory.CreateClient();
        }

        [TestMethod]
        public async Task AddShow_WithValidCommand_ReturnsOk()
        {
            var command = new CreateShowCommand()
            {
                Name = "Test",
                Language = "en",
                Premiered = DateTime.Now,
                Summary = "Test Summary",
                Genres = new List<string> { "Comedy" }
            };
            var response = await _client.PostAsJsonAsync("/shows", command);

            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public async Task AddShow_WithoutName_ReturnsBadRequest()
        {
            var command = new CreateShowCommand()
            {
                Language = "en",
                Premiered = DateTime.Now,
                Summary = "Test Summary",
                Genres = new List<string> { "Comedy" }
            };
            var response = await _client.PostAsJsonAsync("/shows", command);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task AddShow_WithInvalidGenre_ReturnsBadRequest()
        {
            var command = new CreateShowCommand()
            {
                Name = "Test",
                Language = "en",
                Premiered = DateTime.Now,
                Summary = "Test Summary",
                Genres = new List<string> { "Test" }
            };
            var response = await _client.PostAsJsonAsync("/shows", command);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}