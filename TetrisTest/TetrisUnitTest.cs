using Moq;
using TetrisModel;
using TetrisModel.Persistence;

namespace TetrisTest
{
    [TestClass]
    public class TetrisUnitTest
    {
        private GameState _gameState = null!;
        private GameGrid _grid = null!;
        private GameGrid _smallgrid = null!;
        private GameGrid _mediumgrid = null!;
        private Mock<ITetrisDataAccess> _mock = null!;

        [TestInitialize]
        public void Initialize()
        {
            _grid = new GameGrid(18, 12);
            _smallgrid = new GameGrid(18, 4);
            _mediumgrid = new GameGrid(18, 8);
            _mock = new Mock<ITetrisDataAccess>();
            _mock.Setup(mock => mock.LoadScore(It.IsAny<String>())).Returns(0);

        }

        [TestMethod]
        public void SmallGridTest()
        {
            Assert.AreEqual(18, _smallgrid.Rows);
            Assert.AreEqual(4, _smallgrid.Columns);
            Assert.IsTrue(_smallgrid.IsSmall());
            for (int i = 0; i < _smallgrid.Rows; i++)
            {
                Assert.IsTrue(_smallgrid.IsRowEmpty(i));
            }
        }

        [TestMethod]
        public void MediumGridTest()
        {
            Assert.AreEqual(18, _mediumgrid.Rows);
            Assert.AreEqual(8, _mediumgrid.Columns);
            for (int i = 0; i < _mediumgrid.Rows; i++)
            {
                Assert.IsTrue(_mediumgrid.IsRowEmpty(i));
            }
        }

        [TestMethod]
        public void LargeGridTest()
        {
            Assert.AreEqual(18, _grid.Rows);
            Assert.AreEqual(12, _grid.Columns);
            for (int i = 0; i < _grid.Rows; i++)
            {
                Assert.IsTrue(_grid.IsRowEmpty(i));
            }
        }


        [TestMethod]
        public void NewSmallGameTest()
        {
            _mock.Setup(mock => mock.Load(It.IsAny<String>())).Returns(_smallgrid);

            _gameState = new GameState(_mock.Object,String.Empty);
            
            Assert.AreEqual(0, _gameState.Score);
            Assert.AreEqual(GameDifficulty.Easy, _gameState.GameDifficulty);
            Assert.IsFalse(_gameState.GameOver);

            int emptycells = 0;
            for (int r = 0; r < _gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < _gameState.GameGrid.Columns; c++)
                {
                    Assert.IsTrue(_gameState.GameGrid.IsInside(r,c));
                    if (_gameState.GameGrid.IsEmpty(r,c))
                    {
                        emptycells++;
                    }
                }
            }
            Assert.AreEqual(72, emptycells);

            _mock.Verify(dataAccess => dataAccess.Load(String.Empty), Times.Once());
            _mock.Verify(dataAccess => dataAccess.LoadScore(String.Empty), Times.Once());

        }

        [TestMethod]
        public void NewMediumGameTest()
        {
            _mock.Setup(mock => mock.Load(It.IsAny<String>())).Returns(_mediumgrid);

            _gameState = new GameState(_mock.Object, String.Empty);

            Assert.AreEqual(0, _gameState.Score);
            Assert.AreEqual(GameDifficulty.Medium, _gameState.GameDifficulty);
            Assert.IsFalse(_gameState.GameOver);

            int emptycells = 0;
            for (int r = 0; r < _gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < _gameState.GameGrid.Columns; c++)
                {
                    Assert.IsTrue(_gameState.GameGrid.IsInside(r,c));
                    if (_gameState.GameGrid.IsEmpty(r, c))
                    {
                        emptycells++;
                    }
                }
            }
            Assert.AreEqual(144, emptycells);

            _mock.Verify(dataAccess => dataAccess.Load(String.Empty), Times.Once());
            _mock.Verify(dataAccess => dataAccess.LoadScore(String.Empty), Times.Once());
        }
        
        [TestMethod]
        public void NewHardGameTest()
        {
            _mock.Setup(mock => mock.Load(It.IsAny<String>())).Returns(_grid);

            _gameState = new GameState(_mock.Object, String.Empty);

            Assert.AreEqual(0, _gameState.Score);
            Assert.AreEqual(GameDifficulty.Hard, _gameState.GameDifficulty);
            Assert.IsFalse(_gameState.GameOver);

            int emptycells = 0;
            for (int r = 0; r < _gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < _gameState.GameGrid.Columns; c++)
                {
                    Assert.IsTrue(_gameState.GameGrid.IsInside(r,c));
                    if (_gameState.GameGrid.IsEmpty(r, c))
                    {
                        emptycells++;
                    }
                }
            }
            Assert.AreEqual(216, emptycells);

            _mock.Verify(dataAccess => dataAccess.Load(String.Empty), Times.Once());
            _mock.Verify(dataAccess => dataAccess.LoadScore(String.Empty), Times.Once());
        }

        [TestMethod]
        public void CreateAndPlaceBlockTest()
        {
            _mock.Setup(mock => mock.Load(It.IsAny<String>())).Returns(_grid);

            _gameState = new GameState(_mock.Object, "");
             
            _gameState.MoveBlockDown();
            _gameState.DropBlock();

            int emptycells = 0;
            for (int r = 0; r < _gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < _gameState.GameGrid.Columns; c++)
                {
                    if (_gameState.GameGrid.IsEmpty(r, c))
                    {
                        emptycells++;
                    }
                }
            }
            Assert.AreEqual(216 - 4, emptycells);
            
            Assert.IsFalse(_gameState.GameGrid.IsEmpty(17,4));
        }

        [TestMethod]
        public void PlaceBlockLeft()
        {
            _mock.Setup(mock => mock.Load(It.IsAny<String>())).Returns(_grid);

            _gameState = new GameState(_mock.Object, "");

            _gameState.MoveBlockDown();
            for (int i = 0; i < 5; i++)
            {
                _gameState.MoveBlockLeft();
            }
            _gameState.DropBlock();

            int emptycells = 0;
            for (int r = 0; r < _gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < _gameState.GameGrid.Columns; c++)
                {
                    if (_gameState.GameGrid.IsEmpty(r, c))
                    {
                        emptycells++;
                    }
                }
            }
            Assert.AreEqual(216 - 4, emptycells);

            Assert.IsFalse(_gameState.GameGrid.IsEmpty(17, 1));
        }
        
        [TestMethod]
        public void PlaceBlockRight()
        {
            _mock.Setup(mock => mock.Load(It.IsAny<String>())).Returns(_grid);

            _gameState = new GameState(_mock.Object, "");

            _gameState.MoveBlockDown();
            for (int i = 0; i < 10; i++)
            {
                _gameState.MoveBlockRight();
            }
            _gameState.DropBlock();

            int emptycells = 0;
            for (int r = 0; r < _gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < _gameState.GameGrid.Columns; c++)
                {
                    if (_gameState.GameGrid.IsEmpty(r, c))
                    {
                        emptycells++;
                    }
                }
            }
            Assert.AreEqual(216 - 4, emptycells);

            Assert.IsFalse(_gameState.GameGrid.IsEmpty(17, 10));
        }

        [TestMethod]
        public void GameOverTest()
        {
            _mock.Setup(mock => mock.Load(It.IsAny<String>())).Returns(_grid);

            _gameState = new GameState(_mock.Object, "");

            for (int i = 0; i < 11; i++)
            {
                _gameState.DropBlock();
            }
            
            Assert.IsTrue(_gameState.GameOver);
            
        }
    }
}