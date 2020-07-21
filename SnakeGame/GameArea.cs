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
        private int score;

        public GameArea()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }

        private void InitializeGame()
        {
            this.Height = 640;
            this.Width = 640;
            this.Controls.Add(area);
            area.Location = new Point(20, 20);
            area.Height = ClientRectangle.Height - 20 * 2;
            area.Width = ClientRectangle.Width - 20 * 2;

            this.Controls.Add(food);
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
            if(snake.invalidMove())
                GameOver();
            snake.SnakeMove();
            SnakeFoodCollision();
            if(snake.BorderCollision(area))
                GameOver();
            snake.HeadAnimate(snake.headRotateType);
            snake.TailAnimate();
            snake.BodyAnimate(snake.bodyRotateType);
            snake.Render(this);
            snake.turningJointsShifting();
        }       

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                snake.VerVelocity = -snake.Step;
                snake.HorVelocity = 0;                
                snake.headRotateType = RotateFlipType.Rotate180FlipNone;
                //snake.tailRotateType = RotateFlipType.RotateNoneFlipNone;
                snake.bodyRotateType = RotateFlipType.RotateNoneFlipNone;
                if (snake.MovementDirection == "Right")
                {
                    snake.turningJoints[1] = "RightUp";
                }
                if (snake.MovementDirection == "Left")
                {                    
                    snake.turningJoints[1] = "LeftUp";
                }
                snake.turningJoints[0] = "Up";
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {               
                snake.VerVelocity = snake.Step;
                snake.HorVelocity = 0;
                snake.headRotateType = RotateFlipType.RotateNoneFlipNone;
                //snake.tailRotateType = RotateFlipType.Rotate180FlipNone;
                snake.bodyRotateType = RotateFlipType.RotateNoneFlipNone;
                if (snake.MovementDirection == "Right")
                {
                    snake.turningJoints[1] = "RightDown";
                }
                if (snake.MovementDirection == "Left")
                {
                    snake.turningJoints[1] = "LeftDown";
                }
                snake.turningJoints[0] = "Down";
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                
                snake.HorVelocity = -snake.Step;
                snake.VerVelocity = 0;
                snake.headRotateType = RotateFlipType.Rotate90FlipNone;
                //snake.tailRotateType = RotateFlipType.Rotate270FlipNone;
                snake.bodyRotateType = RotateFlipType.Rotate90FlipNone;
                if (snake.MovementDirection == "Up")
                {
                    snake.turningJoints[1] = "UpLeft";
                }
                if (snake.MovementDirection == "Down")
                {
                    snake.turningJoints[1] = "DownLeft";
                }
                snake.turningJoints[0] = "Left";
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {               
                snake.HorVelocity = snake.Step;
                snake.VerVelocity = 0;
                snake.headRotateType = RotateFlipType.Rotate270FlipNone;
                //snake.tailRotateType = RotateFlipType.Rotate90FlipNone;
                snake.bodyRotateType = RotateFlipType.Rotate90FlipNone;
                if (snake.MovementDirection == "Up")
                {
                    snake.turningJoints[1] = "UpRight";
                }
                if (snake.MovementDirection == "Down")
                {
                    snake.turningJoints[1] = "DownRight";
                }
                snake.turningJoints[0] = "Right";
            }
        }

        private void GameOver()
        {
            mainTimer.Stop();
            lblGameOver.Visible = true;
            lblGameOver.BringToFront();
        }

        private void SetFoodLocation()
        {
            int jointCount;
            do
            {
                food.GetFoodLocation();
                jointCount = 0;
                foreach (var item in snake.snakePixels)
                {
                    if (item.Location != food.Location)
                        jointCount++;
                }
            }
            while (jointCount != snake.snakePixels.Count);
            food.BringToFront();
        }

        private void SnakeFoodCollision()
        {
            if (snake.snakePixels[0].Bounds.IntersectsWith(food.Bounds))
            {
                score += 10;
                SetFoodLocation();
                int left = snake.snakePixels[snake.snakePixels.Count - 1].Left;
                int top = snake.snakePixels[snake.snakePixels.Count - 1].Top;
                snake.AddPixel(left, top);
                snake.Render(this);
                //if (mainTimer.Interval >= 20)
                //    mainTimer.Interval -= 20;
            }
        }
    }
}
