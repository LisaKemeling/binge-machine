using System.Collections.ObjectModel;
using System.Reflection;
using Newtonsoft.Json;
using XPRTZ.BingeMachine.Shows.TvMaze.Infrastructure;

namespace XPRTZ.BingeMachine.Shows.DeserializerTests
{
    public class DummyData
    {
        public List<Show> Shows { get; }

        public DummyData()
        {
            var assembly = typeof(DummyData).GetTypeInfo().Assembly;
            var resource = assembly.GetManifestResourceStream("XPRTZ.BingeMachine.Shows.DeserializerTests.DummyData.json");
            var reader = new StreamReader(resource ?? throw new InvalidOperationException("DummyData.json not found or empty"));
            var data = reader.ReadToEnd();
            var dynamicData = JsonConvert.DeserializeObject<Collection<Show>>(data);
            Shows = dynamicData.ToList();
        }

    }
}
