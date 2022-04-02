using System;
using System.Drawing;
using System.IO;

namespace OOP_laba_8.Core
{
    public class Circle : Shape
    {
        protected int rad;
        protected Color color;

        public Circle()
        {
            x = 0;
            y = 0;
            rad = 0;
        }

        public Circle(int x, int y, int r, Color c, int Width, int Height)
        {
            width = Width;
            height = Height;
            this.x = x;
            this.y = y;
            color = c;
            //контроль выхода за границы при инициализации
            if (r > x) r = x;
            if (x + r > width) r = width - x;
            if (r > y) r = y;
            if (y + r > height) r = height - y;
            rad = r;
            rec = new Rectangle(x - rad, y - rad, 2 * rad, 2 * rad);
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Black, 2), rec);
            g.FillEllipse(new SolidBrush(color), rec);
        }

        public override void SetColor(Color c)
        {
            color = c;
        }

        public override void Move(int xx, int yy)
        {
            if (repos != null && repos.getSize() != 0 && sticky == true)
            {
                repos.toFirst();
                for (int i = 0; i < repos.getSize(); i++, repos.next())
                {
                    if (Find(repos.getIterator()) == true && repos.getIterator() != this)
                    {
                        if (repos.getIterator().sticky == false)
                            repos.getIterator().Move(xx, yy);
                    }
                }
            }
            if (x + xx > rad && x + xx + rad < width) x += xx;
            if (y + yy > rad && y + yy + rad < height) y += yy;

            Resize();
        }

        public override void Resize()
        {
            rec = new Rectangle(x - rad, y - rad, rad * 2, rad * 2);
        }

        public override void DrawRec(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, rec);
        }

        public override void Grow(int i)
        {
            if (rad + i < x && x + rad + i < width && rad + i < y && y + rad + i < height && rad + i > 0) rad += i;
            Resize();
        }

        public override bool Find(Shape s)
        {
            string[] data = s.GetInfo().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (data[0] != "Group")
            {
                int _x = Convert.ToInt32(data[2]);
                int _y = Convert.ToInt32(data[4]);
                int _rad = Convert.ToInt32(data[6]);
                if (Math.Pow(x - _x, 2) + Math.Pow(y - _y, 2) <= Math.Pow(rad + _rad, 2)) return true;
            }
            else 
                return s.Find(this);
            return false;
        }

        public override int GetX()
        {
            return x;
        }

        public override int GetY()
        {
            return y;
        }

        public override Color GetColor()
        {
            return color;
        }

        public override void Rotate(int gr)
        {
        }

        public override void GrowN(int nn)
        {
        }

        public override Rectangle GetRectangle()
        {
            return rec;
        }

        public override bool Find(int _x, int _y)
        {
            if (Math.Pow(x - _x, 2) + Math.Pow(y - _y, 2) <= rad * rad) 
                return true; 
            else 
                return false;
        }

        public override void Save(StreamWriter stream)
        {
            stream.WriteLine("Circle");
            stream.WriteLine((rec.X + rad) + " " + (rec.Y + rad) + " " + rad + " " + color.R + " " + color.G + " " + color.B + " " + width + " " + height);
        }

        public override void Load(StreamReader stream)
        {
            string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            x = Convert.ToInt32(data[0]);
            y = Convert.ToInt32(data[1]);
            rad = Convert.ToInt32(data[2]);
            color = Color.FromArgb(Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToInt32(data[5]));
            width = Convert.ToInt32(data[6]);
            height = Convert.ToInt32(data[7]);
            Resize();
        }

        public override string GetInfo()
        {
            return "Circle" + "  X: " + x + " Y: " + y + " Rad: " + rad + " " + color.ToString();
        }
    }
}
