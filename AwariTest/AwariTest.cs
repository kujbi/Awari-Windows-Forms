using Awari.Model;
using Awari.Persistence;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;



namespace Awari.Test
{
    [TestClass]
    public class AwariTest
    {
        private AwariGameModel _model;
        private AwariTable _mocktable;
        private Mock<IAwariDataAccess> _mock;

        [TestInitialize]
        public void Initialize()
        {
            _mocktable = new AwariTable();
            _mocktable.SetValue(0,1);
            _mocktable.SetValue(1,1);
            _mocktable.SetValue(2,2);
     

            _mock = new Mock<IAwariDataAccess>();
            _mock.Setup(mock => mock.LoadAsync(It.IsAny<String>())).Returns(() => Task.FromResult(_mocktable));
           

            _model = new AwariGameModel(_mock.Object);
            // példányosítjuk a modellt a mock objektummal
           
            _model.GameOver += new EventHandler<AwariEventArgs>(Model_GameOver);
        }


        [TestMethod]
        public void AwariGameModelOriginalTest()
        {
            _model.NewGame();
            ///Checking the Original Gamediff
            Assert.AreEqual(GameDifficulty.Nyolcas, _model.GameDifficulty);
            ///Both Red and Blue score Cup's has 0 stones in it.
            Assert.AreEqual(0, _model.Table.GetValue(_model.Table.NNumber / 2));
            Assert.AreEqual(0, _model.Table.GetValue(_model.Table.TableSize-1));
            ///8-Cup Game
            Assert.AreEqual(8, _model.Table.NNumber);
            ///Red Player's starter cups each have 6 stones in it.
            for (int i = 0; i < _model.Table.NNumber / 2; i++)
            {
                Assert.AreEqual(6, _model.Table.GetValue(i));
            }
            ///Blue Player's starter cups each have 6 stones in it.
            for (int i = (_model.Table.NNumber / 2)+1; i < _model.Table.TableSize - 1; i++)
            {
                Assert.AreEqual(6, _model.Table.GetValue(i));
            }

        }

        [TestMethod]
        public void AwariGameModelNewGameFourTest()
        {
            _model.GameDifficulty = GameDifficulty.Negyes;
            _model.NewGame();
            ///Checking Difficulty
            Assert.AreEqual(GameDifficulty.Negyes, _model.GameDifficulty); 
            ///Both Red and Blue score Cup's has 0 stones in it.
            Assert.AreEqual(0, _model.Table.GetValue(_model.Table.NNumber / 2));
            Assert.AreEqual(0, _model.Table.GetValue(_model.Table.TableSize - 1));
            ///4-Cup Game
            Assert.AreEqual(4, _model.Table.NNumber);
            ///Red Player's starter cups each have 6 stones in it.
            for (int i = 0; i < _model.Table.NNumber / 2; i++)
            {
                Assert.AreEqual(6, _model.Table.GetValue(i));
            }
            ///Blue Player's starter cups each have 6 stones in it.
            for (int i = (_model.Table.NNumber / 2) + 1; i < _model.Table.TableSize - 1; i++)
            {
                Assert.AreEqual(6, _model.Table.GetValue(i));
            }
        }

        [TestMethod]
        public void AwariGameModelNewGamerTwelveTest()
        {
            _model.GameDifficulty = GameDifficulty.Tizenkettes;
            _model.NewGame();
            ///Checking Difficulty
            Assert.AreEqual(GameDifficulty.Tizenkettes, _model.GameDifficulty);
            ///Both Red and Blue score Cup's has 0 stones in it.
            Assert.AreEqual(0, _model.Table.GetValue(_model.Table.NNumber / 2));
            Assert.AreEqual(0, _model.Table.GetValue(_model.Table.TableSize - 1));
            ///12-Cup Game
            Assert.AreEqual(12, _model.Table.NNumber);
            ///Red Player's starter cups each have 6 stones in it.
            for (int i = 0; i < _model.Table.NNumber / 2; i++)
            {
                Assert.AreEqual(6, _model.Table.GetValue(i));
            }
            ///Blue Player's starter cups each have 6 stones in it.
            for (int i = (_model.Table.NNumber / 2) + 1; i < _model.Table.TableSize - 1; i++)
            {
                Assert.AreEqual(6, _model.Table.GetValue(i));
            }
        }

        [TestMethod]
        public async Task AwariGameModelLoadTest()
        {           
            _model.NewGame();
            await _model.LoadGameAsync(String.Empty);                   
            _mock.Verify(dataAccess => dataAccess.LoadAsync(String.Empty), Times.Once());
        }

        private void Model_GameOver(Object sender, AwariEventArgs e)
        {
            Assert.IsTrue(_model.IsGameOver);            
        }

    }
}
