using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroOnline.Client
{
    internal class BoardUI
    {
        private readonly Panel _panel;
        private readonly Button[,] _buttons;
        private readonly GameLogic _game;

        private const int CellSize = 35;

        public BoardUI(Panel panel)
        {
            _panel = panel;
            _game = new GameLogic();
            _buttons = new Button[Board.Rows, Board.Cols];

            CreateBoard();
        }

        private void CreateBoard()
        {
            _panel.Controls.Clear();

            for (int row = 0; row < Board.Rows; row++)
            {
                for (int col = 0; col < Board.Cols; col++)
                {
                    Button button = new Button();

                    button.Width = CellSize;
                    button.Height = CellSize;

                    button.Left = col * CellSize;
                    button.Top = row * CellSize;

                    button.Tag = new Point(row, col);

                    button.Font = new Font("Arial", 12, FontStyle.Bold);

                    button.Click += Button_Click;

                    _buttons[row, col] = button;


                    _panel.Controls.Add(button);
                }
            }

        }
        private void Button_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender!;

            Point p = (Point)button.Tag!;

            if (_game.MakeMove(p.X, p.Y))
            {
                int player = _game.Board.Get(p.X, p.Y);

                button.Text = player == 1 ? "X" : "O";

                button.Enabled = false;
            }
        }
    }
}