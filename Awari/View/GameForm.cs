using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Awari.Model;
using Awari.Persistence;

namespace Awari
{
    public partial class GameForm : Form
    {
        private IAwariDataAccess _dataAccess; // adatelérés
        private AwariGameModel _model; // játékmodell
        private Button[] _button;
        
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // adatelérés példányosítása
            _dataAccess = new AwariFileDataAccess();           
            _model = new AwariGameModel(_dataAccess);
            _model.GameOver += new EventHandler<AwariEventArgs>(Game_GameOver);
                           
            GenerateTable();            
            SetupMenus();
            _model.NewGame();                    
            ButtonRestrict();
        }
        
     

       

        private void Game_GameOver(Object sender, AwariEventArgs e)
        {
            for (int i = 0; i < _model.Table.TableSize-1; i++)
            {
                _button[i].Enabled = false;
            }
            _menuFileSaveGame.Enabled = false;
            if (e.WhoWon == 0) // győztestől függő üzenet megjelenítése
            {
                MessageBox.Show("Gratulálok Piros játékos győztél."
                                ,
                                "Awari játék",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
            }
            else if (e.WhoWon == 1)
            {
                MessageBox.Show("Gratulálok Kék játékos győztél!",
                                "Awari játék",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
            }
            else if (e.WhoWon == 2)
            {
                MessageBox.Show("Gratulálok döntetlen lett!",
                                   "Awari játék",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Asterisk);

            }

           Thread.Sleep(5000);
           Close();
        }

        private void MenuFileNewGame_Click(Object sender, EventArgs e)
        {
            _menuFileSaveGame.Enabled = true;
            for (int i = 0; i < _model.Table.TableSize; i++)
            {
                Controls.Remove(_button[i]);
                _button[i].Dispose();
            }
            _model.NewGame();
            GenerateTable();
            ButtonRestrict();         
            SetupMenus();
        }

        /// <summary>
        /// Játék betöltésének eseménykezelője.
        /// </summary>
        private async void MenuFileLoadGame_Click(Object sender, EventArgs e)
        {


            if (_openFileDialog.ShowDialog() == DialogResult.OK) // ha kiválasztottunk egy fájlt
            {
                try
                {                
                    //button clearing
                    for (int i = 0; i < _model.Table.TableSize; i++)
                    {
                        Controls.Remove(_button[i]);
                        _button[i].Dispose();
                    }
                    // játék betöltése               
                    await _model.LoadGameAsync(_openFileDialog.FileName);
                    _menuFileSaveGame.Enabled = true;
                }
                catch (AwariDataException)
                {
                    MessageBox.Show("Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _model.NewGame();                   
                    _menuFileSaveGame.Enabled = true;
                }
                GenerateTable();
                // Az értékek gombra való kirása.
                for (int i = 0; i < _model.Table.TableSize; i++)
                {
                    _button[i].Text = _model.Table.GetValue(i).ToString();
                }
                ButtonRestrict();

            }


        }


        private void ButtonRestrict()
        {
            if (_model.CurrentPlayer == 0)
            {
                for (int i =_model.Table.NNumber/2+1; i < _model.Table.TableSize-1; i++)
                {
                    _button[i].Enabled = false;
                    _button[i].BackColor = Color.SkyBlue;
                }
                for (int i = 0; i < _model.Table.NNumber / 2; i++)
                {
                    _button[i].Enabled = true;
                    _button[i].BackColor = Color.Green;
                }
                for (int i = 0; i < _model.Table.NNumber/2; i++)
                {
                    if (_model.Table.GetValue(i)==0)
                    {
                        _button[i].Enabled = false;
                    }
                }
            }
            if (_model.CurrentPlayer == 1)
            {
                for (int i = 0; i < _model.Table.NNumber/2; i++)
                {
                    _button[i].Enabled = false;
                    _button[i].BackColor = Color.Red;
                }
                for (int i = _model.Table.NNumber/2 + 1; i < _model.Table.TableSize-1; i++)
                {
                    _button[i].Enabled = true;
                    _button[i].BackColor = Color.Green;
                }
                for (int i = _model.Table.NNumber / 2+1; i < _model.Table.TableSize-1; i++)
                {
                    if (_model.Table.GetValue(i) == 0)
                    {
                        _button[i].Enabled = false;
                    }
                }
            }
            


        }
        public Boolean second = false;
        private void ButtonGrid_MouseClick(Object sender, MouseEventArgs e)
        {           
            // az index megkapása.
            var mybutton = sender as Button;
            Int32 x =(int)mybutton.Tag;
            if (second)
                second = _model.StonePacking(_model.CurrentPlayer, x,false);
            else
            {               
                second = _model.StonePacking(_model.CurrentPlayer, x, true);
            }
            if (!second)
            {
                _model.ChangePlayer();
            }          
            
            ButtonRestrict();

            // Az értékek gombra való kirása.
            for (int i = 0; i < _model.Table.TableSize; i++)
            {
                _button[i].Text = _model.Table.GetValue(i).ToString();
            }
            Boolean over = false;
            over = _model.IsGameOver;
            if (over)
            {
                /// Red Player Cup Score compared to Blue Player's Cup
                if (_model.Table.GetValue(_model.Table.NNumber / 2) > _model.Table.GetValue(_model.Table.TableSize - 1))
                {
                    _model.OnGameOver(0);
                }
                else if (_model.Table.GetValue(_model.Table.NNumber / 2) < _model.Table.GetValue(_model.Table.TableSize - 1))
                {
                    _model.OnGameOver(1);
                }
                else
                {
                    _model.OnGameOver(2);
                }
            }

        }

        /// <summary>
        /// Játék mentésének eseménykezelője.
        /// </summary>
        private async void MenuFileSaveGame_Click(Object sender, EventArgs e)
        {

            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // játék mentése
                    await _model.SaveGameAsync(_saveFileDialog.FileName);
                }
                catch (AwariDataException)
                {
                    MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        /// <summary>
        /// Kilépés eseménykezelője.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuFileExit_Click(Object sender, EventArgs e)
        {

            // megkérdezzük, hogy biztos ki szeretne-e lépni
            if (MessageBox.Show("Biztosan ki szeretne lépni?", "Awari játék", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // ha igennel válaszol
                Close();
            }
            
        }

        private void MenuGameFour_Click(Object sender, EventArgs e)
        {
            _model.GameDifficulty = GameDifficulty.Negyes;
        }

        private void MenuGameEight_Click(Object sender, EventArgs e)
        {
            _model.GameDifficulty = GameDifficulty.Nyolcas;
        }

        private void MenuGameTwelve_Click(Object sender, EventArgs e)
        {
            _model.GameDifficulty = GameDifficulty.Tizenkettes;
        }









        private void GenerateTable()
        {
            _button = new Button[_model.Table.TableSize];
            for (Int32 i = 0; i < _model.Table.TableSize; i++)
            {
                _button[i] = new Button();
                if (_model.Table.NNumber / 2 > i)
                {
                    _button[i].Location = new Point(130 + 100 * i, 300);
                    _button[i].BackColor = Color.Red;
                     
                   
                }
                else if (_model.Table.NNumber / 2 == i)// elhelyezkedés
                {
                    _button[i].Location = new Point(130 + 100 * i, 250);
                    _button[i].BackColor = Color.Red;
                    
                }
                else if (_model.Table.TableSize - 1 > i)
                {
                    _button[i].Location = new Point(130 + 100 * (_model.Table.NNumber - i), 200);
                    _button[i].BackColor = Color.SkyBlue;
                }
                else
                {
                    _button[i].Location = new Point(10, 250);
                    _button[i].BackColor = Color.SkyBlue;                 
                }
                _button[i].Tag = i;
                _button[i].Text = _model.Table.GetValue(i).ToString();           
                _button[i].Size = new Size(50, 50);
                _button[i].Enabled = false;
                _button[i].Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);                
                _button[i].TabIndex = 100 + i * _model.Table.TableSize;
                _button[i].FlatStyle = FlatStyle.Flat; 
                _button[i].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);
                // közös eseménykezelő hozzárendelése minden gombhoz

                Controls.Add(_button[i]);
                // felvesszük az ablakra a gombot
            }           
            
        }
        private void SetupMenus()
        {
            _menuGameFour.Checked = (_model.GameDifficulty == GameDifficulty.Negyes);
            _menuGameEight.Checked = (_model.GameDifficulty == GameDifficulty.Nyolcas);
            _menuGameTwelve.Checked = (_model.GameDifficulty == GameDifficulty.Tizenkettes);
        }
       

       
    }
}
