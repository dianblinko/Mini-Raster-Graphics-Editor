using System;
using System.Drawing;
using System.IO;

namespace OOP_laba_8.Core
{
    public class SGroup : Shape
    {
        public Repository repository;
        public SGroup()
        {
            repository = new Repository();
        }

        public SGroup(int Width, int Height)
        {
            width = Width;
            height = Height;
            repository = new Repository();
        }

        public void Add(Shape s)
        {
            repository.push_next(s);
            if (repository.getSize() == 1)
            {
                rec = new Rectangle(s.GetRectangle().X, s.GetRectangle().Y, s.GetRectangle().Width, s.GetRectangle().Height);
            }
            else
            {
                if (s.GetRectangle().Left < rec.Left)
                {
                    int tmp = rec.Right;
                    rec.X = s.GetRectangle().Left;
                    rec.Width = tmp - rec.X;
                }
                if (s.GetRectangle().Right > rec.Right)
                {
                    rec.Width = s.GetRectangle().Right - rec.X;
                }
                if (s.GetRectangle().Top < rec.Top)
                {
                    int tmp = rec.Bottom;
                    rec.Y = s.GetRectangle().Top;
                    rec.Height = tmp - rec.Y;
                }
                if (s.GetRectangle().Bottom > rec.Bottom)
                {
                    rec.Height = s.GetRectangle().Bottom - rec.Y;
                }
            }
        }

        public Shape Out()
        {
            if (repository.getSize() != 0)
            {
                Shape tmp = repository.peek_cur();
                repository.pop_cur();
                Resize();
                return tmp;
            }
            return null;
        }

        public int size()
        {
            return repository.getSize();
        }

        public override void Resize()
        {
            if (repository.getSize() != 0)
            {
                repository.toFirst();
                rec = repository.getIterator().GetRectangle();
                for (int i = 0; i < repository.getSize(); i++, repository.next())
                {
                    if (repository.getIterator().GetRectangle().Left < rec.Left)
                    {
                        int tmp = rec.Right;
                        rec.X = repository.getIterator().GetRectangle().Left;
                        rec.Width = tmp - rec.X;
                    }
                    if (repository.getIterator().GetRectangle().Right > rec.Right) rec.Width = repository.getIterator().GetRectangle().Right - rec.X;
                    if (repository.getIterator().GetRectangle().Top < rec.Top)
                    {
                        int tmp = rec.Bottom;
                        rec.Y = repository.getIterator().GetRectangle().Top;
                        rec.Height = tmp - rec.Y;
                    }
                    if (repository.getIterator().GetRectangle().Bottom > rec.Bottom) rec.Height = repository.getIterator().GetRectangle().Bottom - rec.Y;
                }
            }
        }

        public override void Draw(Graphics e)
        {
            if (repository.getSize() != 0)
            {
                repository.toFirst();
                for (int i = 0; i < repository.getSize(); i++, repository.next()) repository.getIterator().Draw(e);
            }
        }

        public override void Grow(int gr)
        {
            if (repository.getSize() != 0)
            {
                if (gr > 0 && rec.X + gr > 1 && gr + rec.Right < width - 1 && rec.Y + gr > 1 && gr + rec.Bottom < height - 1)
                {
                    rec.X -= gr;
                    rec.Y -= gr;
                    rec.Width += 2 * gr;
                    rec.Height += 2 * gr;
                    repository.toFirst();
                    for (int i = 0; i < repository.getSize(); i++, repository.next()) repository.getIterator().Grow(gr);
                }
                if (gr < 0)
                {
                    repository.toFirst();
                    for (int i = 0; i < repository.getSize(); i++, repository.next()) repository.getIterator().Grow(gr);
                    if (gr < 0) Resize();
                }
            }
        }

        public override void Move(int _x, int _y)
        {
            if (repository.getSize() != 0)
            {
                if (rec.X + _x > 0 && _x + rec.Right < width)
                {
                    rec.X += _x;
                    repository.toFirst();
                    for (int i = 0; i < repository.getSize(); i++, repository.next())
                    {
                        repository.getIterator().Move(_x, 0);
                    }
                }
                if (rec.Y + _y > 0 && _y + rec.Bottom < height)
                {
                    rec.Y += _y;
                    repository.toFirst();
                    for (int i = 0; i < repository.getSize(); i++, repository.next())
                    {
                        repository.getIterator().Move(0, _y);
                    }
                }
            }
        }

        public override void SetColor(Color c)
        {
            if (repository.getSize() != 0)
            {
                repository.toFirst();
                for (int i = 0; i < repository.getSize(); i++, repository.next())
                {
                    repository.getIterator().SetColor(c);
                }
            }
        }

        public override Rectangle GetRectangle()
        {
            return rec;
        }

        public override bool Find(int _x, int _y)
        {
            if (rec.X < _x && _x < rec.Right && rec.Y < _y && _y < rec.Bottom)
            {
                return true;
            }
            
            return false;
        }

        public override void DrawRec(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, rec);
        }

        public override void Save(StreamWriter stream)
        {
            stream.WriteLine("Group");
            stream.WriteLine(repository.getSize() + " " + width + " " + height);
            if (repository.getSize() != 0)
            {
                repository.toFirst();
                for (int i = 0; i < repository.getSize(); i++, repository.next())
                    repository.getIterator().Save(stream);
            }
        }

        public override void Load(StreamReader stream)
        {
            ShapeFactory factory = new ShapeFactory();
            string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int i = Convert.ToInt32(data[0]);
            width = Convert.ToInt32(data[1]);
            height = Convert.ToInt32(data[2]);
            for (; i > 0; i--)
            {
                Shape tmp = factory.createShape(stream.ReadLine());
                tmp.Load(stream);
                Add(tmp);
            }
        }

        public override string GetInfo()
        {
            return "Group" + "    Size : " + repository.getSize().ToString();
        }

        public override void Rotate(int gr)
        {
            if (repository.getSize() != 0)
            {
                repository.toFirst();
                for (int i = 0; i < repository.getSize(); i++, repository.next())
                    repository.getIterator().Rotate(gr);
            }
        }

        public override bool Find(Shape obj)
        {
            if (repository.getSize() != 0)
            {
                repository.toFirst();
                for (int i = 0; i < repository.getSize(); i++, repository.next())
                    if (repository.getIterator().Find(obj) == true)
                    {
                        return true;
                    }
            }

            return false;
        }
        public override void GrowN(int nn)
        {
            if (repository.getSize() != 0)
            {
                repository.toFirst();
                for (int i = 0; i < repository.getSize(); i++, repository.next())
                    repository.getIterator().GrowN(nn);
            }
        }
        public override Color GetColor()
        {
            repository.toFirst();
            return repository.getIterator().GetColor();
        }
        public override int GetX()
        {
            return rec.X;
        }
        public override int GetY()
        {
            return rec.Y;
        }
    }
}
