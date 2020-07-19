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
        Area area = new Area();
        Snake snake = new Snake();
        Timer mainTimer = new Timer();

        public GameArea()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
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

        private void InitializeTimer()
        {
            mainTimer.Interval = 500;
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if(snake.invalidMove())
                GameOver();
            snake.SnakeMove();
            if(snake.BorderCollision(area))
                GameOver();
            snake.Render(this);
        }       

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                snake.VerVelocity = -snake.Step;
                snake.HorVelocity = 0;
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                snake.VerVelocity = snake.Step;
                snake.HorVelocity = 0;
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                snake.HorVelocity = -snake.Step;
                snake.VerVelocity = 0;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                snake.HorVelocity = snake.Step;
                snake.VerVelocity = 0;
            }
        }

        private void GameOver()
        {
            mainTimer.Stop();
            lblGameOver.Visible = true;
        }
    }
}
