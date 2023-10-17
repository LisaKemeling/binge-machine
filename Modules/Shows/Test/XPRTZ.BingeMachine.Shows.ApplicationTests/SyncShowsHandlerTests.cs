using Moq;
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.Application.Sync;
using XPRTZ.BingeMachine.Shows.Application.Sync.Port;
using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.ApplicationTests
{
    [TestClass]
    public class SyncShowsHandlerTests
    {
        private SyncShowsHandler _syncShowsHandler;
        private Mock<IShowsRetriever> _showsRetriever = new();
        private Mock<ISyncInfoHandler> _syncInfoHandler= new();
        private Mock<IShowsSyncPersister> _showsSyncPersister = new();

        public SyncShowsHandlerTests()
        {
            _showsSyncPersister.Setup(x => x.SyncAsync(It.IsAny<List<Show>>()))
                .ReturnsAsync(0);
            _syncInfoHandler.Setup(x => x.AddAsync(It.IsAny<SyncInfo>()))
                .ReturnsAsync(0);
        }

        [TestMethod]
        public async Task Handle_WithNonExistingInfoEmptyResponse_StartsAt0StopsAfterOneCall()
        {
            //arrange
            _syncInfoHandler.Setup(x => x.RetrieveAsync()).ReturnsAsync(new SyncInfo(){});
            _showsRetriever.Setup(x => x.RetrieveAsync(It.IsAny<int>())).ReturnsAsync(new List<Show>());
            _syncShowsHandler = new SyncShowsHandler(_showsRetriever.Object, _syncInfoHandler.Object, _showsSyncPersister.Object);

            //act
            var result = await _syncShowsHandler.HandleAsync(new SyncShowsCommand());

            //assert
            _showsRetriever.Verify(x => x.RetrieveAsync(0), Times.Once);
        }

        [TestMethod]
        public async Task Handle_WithNonExistingInfoEmptyAt2_StartsAt0StopsAfterThird()
        {
            //arrange
            _syncInfoHandler.Setup(x => x.RetrieveAsync()).ReturnsAsync(new SyncInfo() { });
            _showsRetriever.Setup(x => x.RetrieveAsync(2)).ReturnsAsync(new List<Show>());
            _showsRetriever.Setup(x => x.RetrieveAsync(1)).ReturnsAsync(new List<Show>(){new Show(){TvMazeId = 420, Name = "Show"}});
            _showsRetriever.Setup(x => x.RetrieveAsync(0)).ReturnsAsync(new List<Show>(){new Show(){TvMazeId = 28, Name = "ShowShow" }});
            _syncShowsHandler = new SyncShowsHandler(_showsRetriever.Object, _syncInfoHandler.Object, _showsSyncPersister.Object);

            //act
            var result = await _syncShowsHandler.HandleAsync(new SyncShowsCommand());

            //assert
            _showsRetriever.Verify(x => x.RetrieveAsync(It.IsAny<int>()), Times.Exactly(3));
            _syncInfoHandler.Verify(x => x.AddAsync(It.Is<SyncInfo>(s =>s.Id == 420)), Times.Once);
        }

    }
}