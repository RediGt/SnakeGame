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
            if(snake.invalidMove())
                GameOver();
            snake.SnakeMove();
            SnakeFoodCollision();
            if(snake.BorderCollision(area))
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
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
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
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {               
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
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {                
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
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {               
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
