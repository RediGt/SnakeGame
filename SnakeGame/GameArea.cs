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
        Food food = new Food();
        int foodIndex;
        private int score;
        int settingsAreaWidth = 260;
        Panel areaPanel = new Panel();

        public GameArea()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
            InitializeSettingsArrow();
            InitializeSettingsPanel();
            this.KeyPreview = true;
        }

        private void InitializeGame()
        {
            this.Height = 640;
            this.Width = 860;
           
            
            this.Controls.Add(area);
            area.Location = new Point(20, 20);
            area.Height = ClientRectangle.Height - 20 * 2;
            area.Width = ClientRectangle.Width - settingsAreaWidth;  //580
                       
            for (int i = 0; i < 3; i++)
            {
                this.Controls.Add(food.foodCollection[i]);
                food.foodCollection[i].Visible = false;
            }

            SetFoodLocation();
            score = 0;

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
            if (snake.snakeIntersected())
                GameOver();
            snake.SnakeMove();
            SnakeFoodCollision();
            if (snake.BorderCollision(area))
                GameOver();
            snake.HeadAnimate();
            snake.TailAnimate();
            snake.BodyAnimate();
            snake.TurnAnimate();
            snake.Render(this);
            snake.turningJointsShifting();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    if (snake.VerVelocity == snake.Step)
                        return;
                    snake.VerVelocity = -snake.Step;
                    snake.HorVelocity = 0;

                    if (snake.turningJoints[0] == MoveDirection.Right)
                    {
                        snake.turningJoints[1] = MoveDirection.RightUp;
                    }

                    if (snake.turningJoints[0] == MoveDirection.Left)
                    {
                        snake.turningJoints[1] = MoveDirection.LeftUp;
                    }
                    snake.turningJoints[0] = MoveDirection.Up;
                    break;

                case Keys.S:
                case Keys.Down:
                    if (snake.VerVelocity == -snake.Step)
                        return;
                    snake.VerVelocity = snake.Step;
                    snake.HorVelocity = 0;

                    if (snake.turningJoints[0] == MoveDirection.Right)
                    {
                        snake.turningJoints[1] = MoveDirection.RightDown;
                    }

                    if (snake.turningJoints[0] == MoveDirection.Left)
                    {
                        snake.turningJoints[1] = MoveDirection.LeftDown;
                    }
                    snake.turningJoints[0] = MoveDirection.Down;
                    break;

                case Keys.A:
                case Keys.Left:
                    if (snake.HorVelocity == snake.Step)
                        return;
                    snake.HorVelocity = -snake.Step;
                    snake.VerVelocity = 0;

                    if (snake.turningJoints[0] == MoveDirection.Up)
                    {
                        snake.turningJoints[1] = MoveDirection.UpLeft;
                    }

                    if (snake.turningJoints[0] == MoveDirection.Down)
                    {
                        snake.turningJoints[1] = MoveDirection.DownLeft;
                    }
                    snake.turningJoints[0] = MoveDirection.Left;
                    break;

                case Keys.D:
                case Keys.Right:
                    if (snake.HorVelocity == -snake.Step)
                        return;
                    snake.HorVelocity = snake.Step;
                    snake.VerVelocity = 0;

                    if (snake.turningJoints[0] == MoveDirection.Up)
                    {
                        snake.turningJoints[1] = MoveDirection.UpRight;
                    }

                    if (snake.turningJoints[0] == MoveDirection.Down)
                    {
                        snake.turningJoints[1] = MoveDirection.DownRight;
                    }
                    snake.turningJoints[0] = MoveDirection.Right;
                    break;
            }
        }

        private void GameOver()
        {
            mainTimer.Stop();
            lblGameOver.Text = "GAME OVER";
            lblGameOver.Visible = true;
            lblGameOver.BringToFront();
        }

        private void SetFoodLocation()
        {
            int jointCount;
            food.foodCollection[0].Visible = false;
            food.foodCollection[1].Visible = false;
            food.foodCollection[2].Visible = false;
            foodIndex = food.FoodIndex();
            do
            {
                food.GetFoodLocation(foodIndex);
                jointCount = 0;
                foreach (var item in snake.snakePixels)
                {
                    if (item.Location != food.foodCollection[foodIndex].Location)
                        jointCount++;
                }
            }
            while (jointCount != snake.snakePixels.Count);
            food.foodCollection[foodIndex].BringToFront();
            food.foodCollection[foodIndex].Visible = true;
        }

        private void SnakeFoodCollision()
        {
            if (snake.snakePixels[0].Bounds.IntersectsWith(food.foodCollection[foodIndex].Bounds))
            {
                score += 10;
                lblScore.Text = "Score : " + score;
                SetFoodLocation();
                int left = snake.snakePixels[snake.snakePixels.Count - 1].Left;
                int top = snake.snakePixels[snake.snakePixels.Count - 1].Top;
                snake.AddPixel(left, top);
                snake.Render(this);
                if (score >= 200)
                    LevelCompleted();
                if (mainTimer.Interval >= 20)
                    mainTimer.Interval -= 20;
            }
        }

        private void LevelCompleted()
        {
            mainTimer.Stop();
            lblGameOver.Text = "LEVEL 1. COMPLETED";
            lblGameOver.Visible = true;
            lblGameOver.BringToFront();
        }

//SETTING PANEL
        PictureBox arrow = new PictureBox();
        ToolTip arrowHint = new ToolTip();
        bool arrowHideSettings = false;
        bool pauseGame = false;

        private void InitializeSettingsPanel()
        {
            panelSettings.Top = Area.CellSize;
            panelSettings.Left = area.Left + area.Width + Area.CellSize;
        }

        private void InitializeSettingsArrow()
        {
            arrow.Height = Area.CellSize;
            arrow.Width = Area.CellSize;
            arrow.BackColor = this.BackColor;
            arrow.SizeMode = PictureBoxSizeMode.StretchImage;
            arrow.Image = Properties.Resources.arrow_left;
            arrow.Location = new Point(area.Width, ClientRectangle.Height - Area.CellSize);

            this.Controls.Add(arrow);
            arrow.Click += new EventHandler(arrow_Click);
            arrow.MouseEnter += new EventHandler(arrow_Enter);
            arrow.MouseLeave += new EventHandler(arrow_Leave);

            arrowHideSettings = false;
        }

        private void arrow_Click(object sender, EventArgs e)
        {
            if (arrowHideSettings == false)
            {
                this.Width = area.Width + Area.CellSize * 3;
                arrowHideSettings = true;
                arrow.Image = Properties.Resources.arrow_right;
            }
            else if (arrowHideSettings)
            {
                this.Width = area.Width + settingsAreaWidth;
                arrow.Image = Properties.Resources.arrow_left;
                arrowHideSettings = false;
            }
        }

        private void arrow_Enter(object sender, EventArgs e)
        {
            if (arrowHideSettings == false)
            {
                arrowHint.Show("Lock the settings", this, Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
            }
            else if (arrowHideSettings)
            {
                arrowHint.Show("Unlock the settings", this, Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
            }
        }
        
        private void arrow_Leave(object sender, EventArgs e)
        {
            arrowHint.Hide(arrow);
        }
       
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (pauseGame == false)
            {
                mainTimer.Stop(); 
                pauseGame = true;
            }
            else if (pauseGame)
            {
                area.Focus();
                mainTimer.Start();
                pauseGame = false;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            mainTimer.Dispose();
            mainTimer = new Timer();
            InitializeTimer();
            
            snake.DisposeSnake(this);
            snake = null;
            snake = new Snake();

            SetFoodLocation();
            score = 0;
            lblScore.Text = "Score : " + score;

            snake.Render(this);
            area.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
