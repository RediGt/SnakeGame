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

        //public string MovementDirection { get; set; } = "Up";

        //public Point headPosition { get; set; }

        public RotateFlipType headRotateType { get; set; } = RotateFlipType.Rotate180FlipNone;
        public RotateFlipType bodyRotateType { get; set; } = RotateFlipType.RotateNoneFlipNone;
        //public RotateFlipType tailRotateType { get; set; } = RotateFlipType.RotateNoneFlipNone;
        //public RotateFlipType turnRotateType { get; set; }

        private void InitializeSnake()
        {
            this.AddPixel(initPositionTop, initPositionLeft);
            this.AddPixel(initPositionTop, initPositionLeft + jointSize);
            this.AddPixel(initPositionTop, initPositionLeft + jointSize * 2);

            //this.HeadAnimate(RotateFlipType.Rotate180FlipNone);
            //this.BodyAnimate(RotateFlipType.RotateNoneFlipNone);
            //this.TailAnimate(RotateFlipType.RotateNoneFlipNone);

            //this.headPosition = this.snakePixels[0].Location;
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
                //Array.Copy(turningJoints, 1, turningJoints, 0, 1);
                turningJoints.Add(turningJoints[turningJoints.Count - 1]);
            else
                turningJoints.Add(MoveDirection.Up);

            /*PictureBox turnPixel = new PictureBox();
            turnPixel.Height = jointSize;
            turnPixel.Width = jointSize;
            turnPixel.Location = new Point(-1, -1);
            turningJoints.Add(turnPixel);*/
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
        
        public void HeadAnimate(RotateFlipType type)
        {
            //snakePixels[0].BackColor = Color.RosyBrown;
            
            Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
            RectangleF cloneRect = new RectangleF(1, 43, 40, 40);
            System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
            Bitmap head1 = initPicture.Clone(cloneRect, format);
            head1.RotateFlip(type);
            snakePixels[0].Image = head1;
            snakePixels[0].SizeMode = PictureBoxSizeMode.StretchImage;            
        }

        public void TailAnimate()// RotateFlipType type)
        {
            //snakePixels[snakePixels.Count-1].BackColor = Color.RosyBrown;

            if (turningJoints[turningJoints.Count - 1] == MoveDirection.UpRight ||
                turningJoints[turningJoints.Count - 1] == MoveDirection.DownRight ||
                (turningJoints[turningJoints.Count - 1] == MoveDirection.Right))
            {              
                Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
                RectangleF cloneRect = new RectangleF(43, 85, 40, 40);
                System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
                Bitmap tail = initPicture.Clone(cloneRect, format);
                tail.RotateFlip(RotateFlipType.Rotate90FlipNone);
                snakePixels[snakePixels.Count - 1].Image = tail;
                snakePixels[snakePixels.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (turningJoints[turningJoints.Count - 1] == MoveDirection.UpLeft ||
                turningJoints[turningJoints.Count - 1] == MoveDirection.DownLeft ||
                (turningJoints[turningJoints.Count - 1] == MoveDirection.Left))
            {
                Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
                RectangleF cloneRect = new RectangleF(43, 85, 40, 40);
                System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
                Bitmap tail = initPicture.Clone(cloneRect, format);
                tail.RotateFlip(RotateFlipType.Rotate270FlipNone);
                snakePixels[snakePixels.Count - 1].Image = tail;
                snakePixels[snakePixels.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (turningJoints[turningJoints.Count - 1] == MoveDirection.RightDown ||
                turningJoints[turningJoints.Count - 1] == MoveDirection.LeftDown ||
                (turningJoints[turningJoints.Count - 1] == MoveDirection.Down))
            {
                Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
                RectangleF cloneRect = new RectangleF(43, 85, 40, 40);
                System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
                Bitmap tail = initPicture.Clone(cloneRect, format);
                tail.RotateFlip(RotateFlipType.Rotate180FlipNone);
                snakePixels[snakePixels.Count - 1].Image = tail;
                snakePixels[snakePixels.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
                RectangleF cloneRect = new RectangleF(43, 85, 40, 40);
                System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
                Bitmap tail = initPicture.Clone(cloneRect, format);
                tail.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                snakePixels[snakePixels.Count - 1].Image = tail;
                snakePixels[snakePixels.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void BodyAnimate() //(RotateFlipType type)
        {            
            for (int i = 1; i < snakePixels.Count-1; i++)
            {               
                if (turningJoints[i] == MoveDirection.Right ||
                    turningJoints[i] == MoveDirection.Left)
                {
                    Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
                    RectangleF cloneRect = new RectangleF(85, 85, 40, 40);
                    System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
                    Bitmap body = initPicture.Clone(cloneRect, format);
                    body.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    snakePixels[i].Image = body;
                    snakePixels[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (turningJoints[i] == MoveDirection.Up ||
                    turningJoints[i] == MoveDirection.Down)
                {
                    Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
                    RectangleF cloneRect = new RectangleF(85, 85, 40, 40);
                    System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
                    Bitmap body = initPicture.Clone(cloneRect, format);
                    body.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    snakePixels[i].Image = body;
                    snakePixels[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }            
        }
        /*
        public void TurnAnimate(RotateFlipType type) //, int bodyPart
        {
            Bitmap initPicture = new Bitmap(Properties.Resources.Snake_sprite_sheet);
            RectangleF cloneRect = new RectangleF(43, 1, 40, 40);
            System.Drawing.Imaging.PixelFormat format = initPicture.PixelFormat;
            Bitmap turningPart = initPicture.Clone(cloneRect, format);
            turningPart.RotateFlip(type);
            snakePixels[bodyPart].Image = turningPart;
            snakePixels[bodyPart].SizeMode = PictureBoxSizeMode.StretchImage;
        }  */ 
        
        public void turningJointsShifting()
        {
            //if (turningJoints[turningJoints.Count-1] != "")
            //{
            //   turningJoints[turningJoints.Count - 1] = "";
            //}

            /*for (int i = turningJoints.Count - 1; i > 0; i--)
            {
                if (turningJoints[i - 1] != turningJoints[i])
                {
                    turningJoints[i] = turningJoints[i - 1];
                    turningJoints[i - 1] = "";
                }
            }*/

            for (int i = turningJoints.Count - 1; i > 0; i--)           
                    turningJoints[i] = turningJoints[i - 1];                                  

            //if (turningJoints[0] != "")
            //{
            //   turningJoints[0] = "";
            //}
        }
    }
}

