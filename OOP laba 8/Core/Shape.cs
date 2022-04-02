using System.Drawing;
using System.IO;

namespace OOP_laba_8.Core
{
    public abstract class Shape : StickObserved
    {
        protected Rectangle rec;
        protected int x, y, width, height;
        public bool sticky = false;

        abstract public void SetColor(Color col);
        abstract public void Draw(Graphics g);
        abstract public void Move(int xx, int yy);
        abstract public void Resize();
        abstract public void DrawRec(Graphics g, Pen pen);
        abstract public void Grow(int i);
        abstract public bool Find(Shape s);
        abstract public bool Find(int _x, int _y);
        abstract public int GetX();
        abstract public int GetY();
        abstract public Color GetColor();
        abstract public void Rotate(int gr);
        abstract public void GrowN(int nn);
        abstract public Rectangle GetRectangle();
        abstract public void Save(StreamWriter stream);
        abstract public void Load(StreamReader stream);
        abstract public string GetInfo();
    }
}
