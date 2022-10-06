using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BrothersSafeGame1
{
    public partial class SafeGame : Form
    {
        private Bitmap _handleX;
        private Bitmap _handleY;
        private int _rowCount;
        private int _columnCount;
        private int _buttonSize;
        private Button[,] _buttons;

        public SafeGame(int rowCount, int columnCount)
        {
            _handleX = Resource1.HandleX;
            _handleY = Resource1.HandleY;
            _buttonSize = 85;

            _rowCount = rowCount;
            _columnCount = columnCount;
            
            _buttons = new Button[_rowCount, _columnCount];

            InitializeComponent();

            Init();
        }

        private void Init()
        {
            InitButtons();

            PlayGame();
        }

        private void InitButtons()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    Button button = new Button();
                    button.Name = i + " " + j;
                    button.Size = new Size(_buttonSize, _buttonSize);
                    button.Location = new Point(j * _buttonSize, i * _buttonSize);
                    button.Image = _handleX;
                    _buttons[i, j] = button;
                    Controls.Add(button);
                }
            }
        }

        private void PlayGame()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {             
                        _buttons[i, j].Click += new EventHandler(OnButtonProceed);
                        _buttons[i, j].Enabled = true;
                }
            }
        }

        private void OnButtonProceed(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;

            string[] buttonLocation = pressedButton.Name.Split(' ');

            int buttonX = Convert.ToInt32(buttonLocation[0]);
            int buttonY = Convert.ToInt32(buttonLocation[1]);

            for (int i = 0; i < _rowCount; i++)
            {
                if (_buttons[buttonX, i].Image == _handleX)
                {
                    _buttons[buttonX, i].Image = _handleY;
                }
                else
                    _buttons[buttonX, i].Image = _handleX;
            }

            for (int i = 0; i < _columnCount; i++)
            {
                if (_buttons[i, buttonY].Image == _handleX)
                    _buttons[i, buttonY].Image = _handleY;
                else
                    _buttons[i, buttonY].Image = _handleX;
            }

            if (_buttons[buttonX, buttonY].Image == _handleX)
                _buttons[buttonX, buttonY].Image = _handleY;
            else
                _buttons[buttonX, buttonY].Image = _handleX;

        }
    }
}
