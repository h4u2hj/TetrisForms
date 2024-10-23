using TetrisModel;
using TetrisModel.Persistence;
using Timer = System.Windows.Forms.Timer;

namespace TetrisView
{
    public partial class TetrisDialog : Form
    {
        private readonly Image[] _tileImages = new Image[]
        {
            new Bitmap("Single Blocks/TileEmpty2.png"),
            new Bitmap("Single Blocks/LightBlue.png"),
            new Bitmap("Single Blocks/Blue.png"),
            new Bitmap("Single Blocks/Orange.png"),
            new Bitmap("Single Blocks/Yellow.png"),
            new Bitmap("Single Blocks/Green.png"),
            new Bitmap("Single Blocks/Purple.png"),
            new Bitmap("Single Blocks/Red.png")
        };

        private readonly Image[] _blockImages = new Image[]
        {
            new Bitmap("Shape Blocks/BlockEmpty.png"),
            new Bitmap("Shape Blocks/I.png"),
            new Bitmap("Shape Blocks/J.png"),
            new Bitmap("Shape Blocks/L.png"),
            new Bitmap("Shape Blocks/O.png"),
            new Bitmap("Shape Blocks/S.png"),
            new Bitmap("Shape Blocks/T.png"),
            new Bitmap("Shape Blocks/Z.png")
        };

        private ITetrisDataAccess _dataAccess = new TetrisDataAccess();
        private Timer _timer = new Timer();
        private bool _isPaused = false;
        private DateTime _startTime;
        private DateTime _pauseStartTime;
        private double _pauseSeconds = 0;
        private PictureBox[,] _imageControls = null!;
        private GameState _gameState = null!;
        private double _pauseMinutes = 0;

        public TetrisDialog()
        {
            InitializeComponent();

            KeyPreview = true;
        }


        /// <summary>
        /// Initializes and sets the picturebox controls according to the game grid
        /// </summary>
        /// <param name="grid">Model's game grid</param>
        /// <returns>Grid of picturebox controls</returns>
        private PictureBox[,] SetupGameCanvas(GameGrid grid, int cellSize)
        {
            PictureBox[,] imageControls = new PictureBox[grid.Rows, grid.Columns];
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Width = cellSize,
                        Height = cellSize,
                        Location = new Point(c * cellSize, (r - 2) * cellSize + 10),
                        BackgroundImageLayout = ImageLayout.Zoom,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    canvasPanel.Controls.Add(pictureBox);
                    imageControls[r, c] = pictureBox;

                }
            }

            return imageControls;
        }


        /// <summary>
        /// Sets the image source to the proper block or empty cell
        /// </summary>
        /// <param name="grid">Model's game grid</param>
        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    _imageControls[r, c].Image = _tileImages[id];
                }
            }
        }

        /// <summary>
        /// Sets the image source to the proper blocks to display a complete block
        /// </summary>
        /// <param name="block">Model's Block to draw</param>
        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePositions())
            {
                _imageControls[p.Row, p.Column].Image = _tileImages[block.Id];
            }
        }

        /// <summary>
        /// Set the next image picture to display the next incoming block
        /// </summary>
        /// <param name="blockQueue">Model's block queue</param>
        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            nextImage.Image = _blockImages[next.Id];
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(_gameState.BlockQueue);
            scoreLabel.Text = $"Score: {_gameState.Score}";
        }


        private void Window_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _gameState.MoveBlockLeft();
                    break;
                case Keys.Right:
                    _gameState.MoveBlockRight();
                    break;
                case Keys.Down:
                    _gameState.MoveBlockDown();
                    break;
                case Keys.Up:
                    _gameState.RotateBlockCW();
                    break;
                case Keys.Z:
                    _gameState.RotateBlockCCW();
                    break;
                case Keys.X:
                    _gameState.DropBlock();
                    break;
                default:
                    return;
            }
            Draw(_gameState);
        }


        /// <summary>
        /// Handles the game loop so the blocks fall down consistently and the game over activates
        /// </summary>
        private void GameLoop(object? sender, EventArgs e)
        {
            Draw(_gameState);
            if (!_gameState.GameOver)
            {
                _gameState.MoveBlockDown();
                Draw(_gameState);
            }
            else
            {
                pauseButton.Visible = false;
                StopGame();
                nextImage.Image = null;
                scoreLabel.Text = $"Final Score: \n{_gameState.Score}\nTime: {(DateTime.Now - _startTime).TotalMinutes - _pauseMinutes:F0} mins\n\t{((DateTime.Now - _startTime).TotalSeconds - _pauseSeconds) % 60:F0} sec";
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (!_isPaused)
            {
                _pauseStartTime = DateTime.Now;
                StopGame();
                _isPaused = true;
                saveButton.Visible = true;
                pinkButton.Visible = true;
                pauseButton.Text = "Play";
            }
            else
            {
                _pauseMinutes += (DateTime.Now - _pauseStartTime).TotalMinutes;
                _pauseSeconds += (DateTime.Now - _pauseStartTime).TotalSeconds;
                ContinueGame();
            }

        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            if (_gameState.GameDifficulty == GameDifficulty.Easy)
            {
                _gameState = new GameState(18, 4, _dataAccess);

            }
            else if (_gameState.GameDifficulty == GameDifficulty.Medium)
            {
                _gameState = new GameState(18, 8, _dataAccess);
            }
            else
            {
                _gameState = new GameState(_dataAccess);
            }
            _pauseSeconds = 0;
            _pauseMinutes = 0;
            ContinueGame();
            _startTime = DateTime.Now;
        }

        private void newEasyGameButton_Click(object? sender, EventArgs e)
        {
            _gameState = new GameState(18, 4, _dataAccess);
            InitializeGame();
        }

        private void newMediumGameButton_Click(object sender, EventArgs e)
        {
            _gameState = new GameState(18, 8, _dataAccess);
            InitializeGame();
        }

        private void newHardGameButton_Click(object? sender, EventArgs e)
        {
            _gameState = new GameState(_dataAccess);
            InitializeGame();
        }

        private void InitializeGame()
        {
            loadButton.Visible = false;
            newEasyGameButton.Visible = false;
            newMediumGameButton.Visible = false;
            newHardGameButton.Visible = false;
            pauseButton.Visible = true;

            switch (_gameState.GameDifficulty)
            {
                case GameDifficulty.Easy:
                    _imageControls = SetupGameCanvas(_gameState.GameGrid, 35);
                    canvasPanel.Size = new Size(140, 570);
                    canvasPanel.Refresh();
                    break;
                case GameDifficulty.Medium:
                    _imageControls = SetupGameCanvas(_gameState.GameGrid, 35);
                    canvasPanel.Size = new Size(280, 570);
                    canvasPanel.Refresh();
                    break;
                case GameDifficulty.Hard:
                    _imageControls = SetupGameCanvas(_gameState.GameGrid, 35);
                    canvasPanel.Size = new Size(420, 570);
                    canvasPanel.Refresh();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Draw(_gameState);
            _timer.Start();
            _timer.Interval = 600;
            _timer.Tick += GameLoop;
            _startTime = DateTime.Now;
            KeyPreview = true;
            KeyDown += Window_KeyDown;
        }

        private void ContinueGame()
        {
            _timer.Start();
            this.KeyDown += Window_KeyDown;
            _isPaused = false;
            loadButton.Visible = false;
            saveButton.Visible = false;
            pinkButton.Visible = false;
            newEasyGameButton.Visible = false;
            newHardGameButton.Visible = false;
            newMediumGameButton.Visible = false;
            pauseButton.Text = "Pause";
            newGameButton.Visible = false;
            pauseButton.Visible = true;
        }
        private void StopGame()
        {
            _timer.Stop();
            this.KeyDown -= Window_KeyDown;
            newGameButton.Visible = true;
        }


        private void loadButton_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _gameState = new GameState(_dataAccess, _openFileDialog.FileName);
                    InitializeGame();
                }
                catch (TetrisDataException ex)
                {
                    MessageBox.Show("Error in loading game!" + Environment.NewLine + "Incorrect path or type" + Environment.NewLine + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _gameState.SaveGame(_saveFileDialog.FileName);
                }
                catch (TetrisDataException ex)
                {
                    MessageBox.Show("Error in saving game!" + Environment.NewLine + "Incorrect path or type" + Environment.NewLine + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pinkButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _tileImages.Length; i++)
            {
                _tileImages[i] = new Bitmap($"Single Blocks/Pink{i}.png");
            }

            canvasPanel.BackColor = Color.FromArgb(247, 166, 200);
            Draw(_gameState);
        }


        //Buttons ignore the key inputs
        private void Button_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Space)
            {
                e.IsInputKey = true;
            }
        }
        private void TetrisDialog_Resize(object sender, EventArgs e)
        {
            canvasPanel.Refresh();
        }
    }
}
