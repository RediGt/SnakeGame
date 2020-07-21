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
        //public List<PictureBox> foodCollection = new List<PictureBox>();
        public Food()
        {
            InitializeFood();           
        }

        /*
        private void InitializeFood()
        {
            foodCollection[0].Image = Properties.Resources.Apple;
            foodCollection[1].Image = Properties.Resources.Pear;
            foodCollection[2].Image = Properties.Resources.Grape;

            for (int i = 0; i < 3; i++)
            {
                foodCollection[i].Width = 20;
                foodCollection[i].Height = 20;
                foodCollection[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }*/

        
        private void InitializeFood()
        {
            this.Width = 20;
            this.Height = 20;
            this.Image = Properties.Resources.Pear;
            this.BackColor = Color.RosyBrown;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        public void GetFoodLocation()
        {
            this.Location = new Point(20 + 20 * rand.Next(0, 29), 20 + 20 * rand.Next(0, 28));
        }
    }
}
