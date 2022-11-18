using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Caro
{
    
    public class MainForm : Form
    {
        Panel pnlChessBoard = new Panel();

        int DISTANCE_20 = 20;
        int CHESS_WIDTH = 40;
        int CHESS_HEIGHT = 40;

        public MainForm()
        {
            Initialize();

            DrawChessBoard();
        }
        private void DrawChessBoard()
        {
            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button btn = new Button()
                    {
                        Width = CHESS_WIDTH,
                        Height = CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    btn.Click += btn_Click;

                    Console.WriteLine($"[{i}, {j}] has location x: {btn.Location.X} and y: {btn.Location.Y} and width: {btn.Width} and height: {btn.Height}");

                    pnlChessBoard.Controls.Add(btn);

                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;

            }
        }
        private void Initialize()
        {
            LoadForm();

            LoadPanelChessBoard();
        }

        private void LoadForm()
        {
            Text = "Game Caro";
            Size = new Size(1040, 800);
            BackColor = SystemColors.ControlLight;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadPanelChessBoard()
        {
            LoadPanel(pnlChessBoard, 680, 720, DISTANCE_20, DISTANCE_20);
        }

        private void LoadPanel(Panel panel, int width, int height, int locationX, int locationY)
        {
            panel.Size = new Size(width, height);
            panel.Location = new Point(locationX, locationY);
            panel.BackColor = Color.LightSkyBlue;

            this.Controls.Add(panel);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Black;
            Console.WriteLine($"Button has location x: {btn.Location.X} and y: {btn.Location.Y} and width: {btn.Width} and height: {btn.Height}");
        }
    }
}
