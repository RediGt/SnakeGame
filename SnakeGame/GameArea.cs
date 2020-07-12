using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class GameArea : Form
    {
        int horVelocity = 0;
        int verVelocity = 0;
        int step = 20;

        Area area = new Area();
        Snake snake = new Snake();
        Timer mainTimer = new Timer();

        public GameArea()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            mainTimer.Interval = 500;
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.invalidMove(horVelocity, verVelocity, mainTimer);
            snake.SnakeMove(horVelocity, verVelocity);
            snake.BorderCollision(area, mainTimer);
            snake.Render(this);
        }

        private void InitializeGame()
        {
            this.Height = 650;
            this.Width = 650;
            this.Controls.Add(area);
            area.Location = new Point(10, 10);
            area.Height = ClientRectangle.Height - 10 * 2;
            area.Width = ClientRectangle.Width - 10 * 2;

            //adding snake body
            snake.Render(this);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                verVelocity = -step;
                horVelocity = 0;
            }
            else if (e.KeyCode == Keys.S)
            {
                verVelocity = step;
                horVelocity = 0;
            }
            else if (e.KeyCode == Keys.A)
            {
                horVelocity = -step;
                verVelocity = 0;
            }
            else if (e.KeyCode == Keys.D)
            {
                horVelocity = step;
                verVelocity = 0;
            }
        }
    }
}
