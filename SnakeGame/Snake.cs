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
        public List<MoveDirection> turningJoints = new List<MoveDirection>();
        int initPositionTop = 200;
        int initPositionLeft = 200;
        int jointSize = 20;      

        public Snake()
        {
            InitializeSnake();
        }

        public int HorVelocity { get; set; } = 0;
        public int VerVelocity { get; set; } = 0;
        public int Step { get; set; } = 20;

        private void InitializeSnake()
        {
            this.AddPixel(initPositionTop, initPositionLeft);
            this.AddPixel(initPositionTop, initPositionLeft + jointSize);
            this.AddPixel(initPositionTop, initPositionLeft + jointSize * 2);
        }

        public void AddPixel(int left, int top)
        {
            PictureBox pixel;
            pixel = new PictureBox();
            pixel.Height = jointSize;
            pixel.Width = jointSize;
            pixel.BackColor = Color.RosyBrown;
            pixel.Location = new Point(left, top);

            snakePixels.Add(pixel);

            if (turningJoints.Count > 1)
                turningJoints.Add(turningJoints[turningJoints.Count - 1]);
            else
                turningJoints.Add(MoveDirection.Up);
        }

        public void Render(Form form)
        {
            foreach (var sp in snakePixels)
            {
                form.Controls.Add(sp);
                sp.BringToFront();
            }
        }

        public void SnakeMove()
        {
            if (snakePixels.Count > 1 && (HorVelocity != 0 || VerVelocity != 0))
            {
                for (int i = snakePixels.Count - 1; i > 0; i--)
                {
                    snakePixels[i].Location = snakePixels[i - 1].Location;
                }
            }
            snakePixels[0].Left += HorVelocity;
            snakePixels[0].Top += VerVelocity;
        }

        public bool BorderCollision(Area area)
        {
            if (snakePixels[0].Location.X < area.Left ||
                snakePixels[0].Location.X > area.Width ||
                snakePixels[0].Location.Y < area.Top ||
                snakePixels[0].Location.Y > area.Height)
            {
                snakePixels[0].BackColor = Color.Red;
                return true;
            }
            return false;
        }

        public bool invalidMove()
        {
            if (snakePixels[0].Left + HorVelocity == snakePixels[1].Left &&
                snakePixels[0].Top + VerVelocity == snakePixels[1].Top)
            {
                snakePixels[0].BackColor = Color.Red;
                return true;
            }
            return false;
        }

        /*public void invalidMove(Timer timer)
        {
            if (snakePixels[0].Left + HorVelocity == snakePixels[1].Left &&
                snakePixels[0].Top + VerVelocity == snakePixels[1].Top)
            {
                snakePixels[0].BackColor = Color.Red;

                //timer.Stop();
                // MessageBox.Show("I ate myself");
            }
        }*/

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
        
        public void HeadAnimate()
        {
            Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
            RectangleF cloneRect = new RectangleF(1, 43, 40, 40);
            System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
            Bitmap head1 = initPicture.Clone(cloneRect, format);

            switch (turningJoints[0])
            {
                case MoveDirection.Left:
                    head1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case MoveDirection.Right:
                    head1.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case MoveDirection.Up:
                    head1.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case MoveDirection.Down:
                    head1.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;
            }
          
            snakePixels[0].Image = head1;
            snakePixels[0].SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void TailAnimate()
        {
            Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
            RectangleF cloneRect = new RectangleF(43, 85, 40, 40);
            System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
            Bitmap tail = initPicture.Clone(cloneRect, format);

            switch (turningJoints[turningJoints.Count - 1])
            {
                case MoveDirection.UpRight:
                case MoveDirection.DownRight:
                case MoveDirection.Right:
                    tail.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case MoveDirection.UpLeft:
                case MoveDirection.DownLeft:
                case MoveDirection.Left:
                    tail.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case MoveDirection.RightDown:
                case MoveDirection.LeftDown:
                case MoveDirection.Down:
                    tail.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case MoveDirection.RightUp:
                case MoveDirection.LeftUp:
                case MoveDirection.Up:
                    tail.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;
            } 
            
            snakePixels[snakePixels.Count - 1].Image = tail;
            snakePixels[snakePixels.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void BodyAnimate()
        {                                   
            for (int i = 1; i < snakePixels.Count-1; i++)
            {                                             
                Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
                RectangleF cloneRect = new RectangleF(85, 85, 40, 40);
                System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
                Bitmap body = initPicture.Clone(cloneRect, format);

                switch (turningJoints[i])
                {
                    case MoveDirection.Left:
                    case MoveDirection.Right:
                        body.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case MoveDirection.Up:
                    case MoveDirection.Down:
                        body.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                        break;
                }

                snakePixels[i].Image = body;
                snakePixels[i].SizeMode = PictureBoxSizeMode.StretchImage;                
            }            
        }
         
        public void TurnAnimate()
        {
            for (int i = 1; i < snakePixels.Count - 1; i++)
            {
                Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
                RectangleF cloneRect = new RectangleF(43, 1, 40, 40);
                System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
                Bitmap turningPart = initPicture.Clone(cloneRect, format);

                switch (turningJoints[i])
                {
                    case MoveDirection.UpRight:
                    case MoveDirection.LeftDown:
                        turningPart.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                        snakePixels[i].Image = turningPart;
                        snakePixels[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    case MoveDirection.UpLeft:
                    case MoveDirection.RightDown:
                        turningPart.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        snakePixels[i].Image = turningPart;
                        snakePixels[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    case MoveDirection.DownLeft:
                    case MoveDirection.RightUp:
                        turningPart.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        snakePixels[i].Image = turningPart;
                        snakePixels[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    case MoveDirection.DownRight:
                    case MoveDirection.LeftUp:
                        turningPart.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        snakePixels[i].Image = turningPart;
                        snakePixels[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                }                
            }
        } 
        
        public void turningJointsShifting()
        {           
            for (int i = turningJoints.Count - 1; i > 0; i--)           
                    turningJoints[i] = turningJoints[i - 1];                                  
        }
    }
}

