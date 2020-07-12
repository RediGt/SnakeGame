using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    class Snake
    {
        public List<PictureBox> snakePixels = new List<PictureBox>();
        int initPositionTop = 200;
        int initPositionLeft = 200;
        int jointSize = 20;

        public Snake()
        {
            InitializeSnake();
        }

        private void InitializeSnake()
        {
            this.AddPixel(initPositionTop, initPositionLeft);
            this.AddPixel(initPositionTop, initPositionLeft + jointSize);
            this.AddPixel(initPositionTop, initPositionLeft + jointSize * 2);
            snakePixels[0].BackColor = Color.White;
        }

        private void AddPixel(int left, int top)
        {
            PictureBox pixel;
            pixel = new PictureBox();
            pixel.Height = jointSize;
            pixel.Width = jointSize;
            pixel.BackColor = Color.SlateGray;
            pixel.Location = new Point(left, top);

            snakePixels.Add(pixel);
        }

        public void Render(Form form)
        {
            foreach (var sp in snakePixels)
            {
                form.Controls.Add(sp);
                sp.BringToFront();
            }
        }
        public void SnakeMove(int X, int Y)
        {
            if (snakePixels.Count > 1 && (X != 0 || Y != 0))
            {
                for (int i = snakePixels.Count - 1; i > 0; i--)
                {
                    snakePixels[i].Location = snakePixels[i - 1].Location;
                }
            }
            snakePixels[0].Left += X;
            snakePixels[0].Top += Y;
        }

        public void BorderCollision(Area area, Timer timer)
        {
            if (snakePixels[0].Location.X < area.Left ||
                snakePixels[0].Location.X > area.Width ||
                snakePixels[0].Location.Y < area.Top ||
                snakePixels[0].Location.Y > area.Height)
            {
                snakePixels[0].BackColor = Color.Red;
                timer.Stop();
                MessageBox.Show("Collision");
            }
        }

        public void invalidMove(int X, int Y, Timer timer)
        {
            if (snakePixels[0].Left + X == snakePixels[1].Left &&
                snakePixels[0].Top + Y == snakePixels[1].Top)
            {
                snakePixels[0].BackColor = Color.Red;
                timer.Stop();
                MessageBox.Show("I ate myself");
            }
        }

        /*
        public bool invalidMove2(int X, int Y)
        {
            if (snakePixels.Count > 1 &&
                snakePixels[0].Left + X == snakePixels[1].Left &&
                snakePixels[0].Top + Y == snakePixels[1].Top)
                return true;
            else
                return false;
        }*/
    }
}

