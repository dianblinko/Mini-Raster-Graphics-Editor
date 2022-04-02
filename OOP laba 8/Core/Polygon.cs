using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace OOP_laba_8.Core
{

    public class Polygon : Circle
    {
        private int n, gr;
        List<PointF> lst;

        public Polygon() : base()
        { 
        }

        public Polygon(int x, int y, int r, Color c, int Width, int Height, int n) : base(x, y, r, c, Width, Height)
        {
            if (n > 3 && n % 2 == 0)
                this.n = n;
            else this.n = 4;
            //контроль выхода за границы при инициализации
            if (r > x) r = x;
            if (x + r > width) r = width - x;
            if (r > y) r = y;
            if (y + r > height) r = height - y;
            Resize();
        }
        public override void Draw(Graphics g)
        {
            g.DrawPolygon(new Pen(Color.Black, 2), lst.ToArray());
            g.FillPolygon(new SolidBrush(color), lst.ToArray());
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
            lst = null;
            lst = new List<PointF>();
            for (int i = gr; i < gr + 360; i += 360 / n)
            {
                double radiani = (double)(i * 3.14) / 180;
                float xx = x + (int)(rad * Math.Cos(radiani));
                float yy = y + (int)(rad * Math.Sin(radiani));
                lst.Add(new PointF(xx, yy));
            }
            rec = new Rectangle(x - rad, y - rad, 2 * rad, 2 * rad);
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
                if (Math.Pow(x - _x, 2) + Math.Pow(y - _y, 2) <= Math.Pow(rad + _rad, 2)) 
                    return true;
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
            this.gr += gr;
            Resize();
        }

        public override void GrowN(int nn)
        {
            if (nn + n > 3 && (nn + n) % 2 == 0) 
                n += nn;
            
            Resize();
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
            stream.WriteLine("Polygon");
            stream.WriteLine(x + " " + y + " " + rad + " " + n + " " + gr + " " + color.R + " " + color.G + " " + color.B + " " + width + " " + height);
        }

        public override void Load(StreamReader stream)
        {
            string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            x = Convert.ToInt32(data[0]);
            y = Convert.ToInt32(data[1]);
            rad = Convert.ToInt32(data[2]);
            n = Convert.ToInt32(data[3]);
            gr = Convert.ToInt32(data[4]);
            color = Color.FromArgb(Convert.ToInt32(data[5]), Convert.ToInt32(data[6]), Convert.ToInt32(data[7]));
            width = Convert.ToInt32(data[8]);
            height = Convert.ToInt32(data[9]);
            Resize();
        }

        public override string GetInfo()
        {
            return "Polygon" + "  X: " + x + " Y: " + y + " Rad: " + rad + " N: " + n + " " + color.ToString();
        }
    }
}
