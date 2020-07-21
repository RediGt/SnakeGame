using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    class Food
    {
        Random rand = new Random();
        public List<PictureBox> foodCollection = new List<PictureBox>();
        public Food()
        {
            InitializeFood();           
        }
      
        private void InitializeFood()
        {           
            for (int i = 0; i < 3; i++)
            {
                PictureBox food = new PictureBox();
                food.Height = Area.CellSize;
                food.Width = Area.CellSize;
                food.BackColor = Color.RosyBrown;
                food.SizeMode = PictureBoxSizeMode.StretchImage;

                foodCollection.Add(food);
            }

            foodCollection[0].Image = Properties.Resources.Apple;
            foodCollection[1].Image = Properties.Resources.Pear;
            foodCollection[2].Image = Properties.Resources.Grape;           
        }     

        public void GetFoodLocation(int foodIndex)
        {
            foodCollection[foodIndex].Location = new Point(20 + 20 * rand.Next(1, 28), 20 + 20 * rand.Next(1, 28));
        }

        public int FoodIndex()
        {
            return rand.Next(0, 3);
        }
    }
}
