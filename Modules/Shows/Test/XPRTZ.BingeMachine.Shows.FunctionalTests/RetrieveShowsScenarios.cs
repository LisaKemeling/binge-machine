using System.Net;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using XPRTZ.BingeMachine.Shows.FunctionalTests.Shared;
using XPRTZ.BingeMachine.Test.Shared;

namespace XPRTZ.BingeMachine.Shows.FunctionalTests
{
    [TestClass]
    public class RetrieveShowsScenarios
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
        public async Task RetrieveShows_WithValidQuery_ReturnsShows()
        {
            var response = await _client.GetAsync("/shows?skip=0&take=15");
            response.EnsureSuccessStatusCode();

            var responseString = response.Content.ReadAsStringAsync().Result;
            var responseObject = JObject.Parse(responseString);

            Assert.AreEqual(1, responseObject["shows"].First["tvMazeId"]);
            Assert.AreEqual(48, responseObject["totalItems"]);
        }

        [TestMethod]
        public async Task RetrieveShows_WithInValidTake_ReturnsBadRequest()
        {
            var response = await _client.GetAsync("/shows?skip=0&take=-1");
           
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task RetrieveShows_WithInValidSKip_ReturnsBadRequest()
        {
            var response = await _client.GetAsync("/shows?skip=-1&take=2");

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}