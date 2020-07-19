using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    class Food : PictureBox
    {
        Random rand = new Random();
        public Food()
        {
            InitializeFood();           
        }

        private void InitializeFood()
        {
            this.Width = 20;
            this.Height = 20;
            this.BackColor = Color.DarkOrange;
        }
        public void GetFoodLocation()
        {
            this.Location = new Point(100 + 20 * rand.Next(0, 20), 100 + 20 * rand.Next(0, 20));
        }

    }
}
