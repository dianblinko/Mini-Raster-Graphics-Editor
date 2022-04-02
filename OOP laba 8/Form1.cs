using OOP_laba_8.Core;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OOP_laba_8
{
    public partial class Form1 : Form
    {
        Repository rep = new Repository();
        Graphics g;
        Tree tree;

        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(pictureBox1);
            pictureBox1.KeyPress += new KeyPressEventHandler(PressEventHandler);
            g = pictureBox1.CreateGraphics();
            tree = new Tree(rep, treeView1);
            rep.AddObserver(tree);
        }

        private void PressEventHandler(Object sender, KeyPressEventArgs e)
        {
            if (rep.getSize() != 0)
            {
                if (e.KeyChar == 119) rep.peek_cur().Move(0, -1);
                if (e.KeyChar == 115) rep.peek_cur().Move(0, 1);
                if (e.KeyChar == 97) rep.peek_cur().Move(-1, 0);
                if (e.KeyChar == 100) rep.peek_cur().Move(1, 0);
                if (e.KeyChar == 107) btnColor_Click(sender, e);
                if (e.KeyChar == 98) rep.peek_cur().Grow(1);
                if (e.KeyChar == 118) rep.peek_cur().Grow(-1);
                if (e.KeyChar == 110) rep.peek_cur().GrowN(2);
                if (e.KeyChar == 109) rep.peek_cur().GrowN(-2);
                if (e.KeyChar == 46) rep.peek_cur().Rotate(2);
                if (e.KeyChar == 44) rep.peek_cur().Rotate(-2);
                if (e.KeyChar == 122)
                {
                    rep.go_prev();
                    colorDialog1.Color = rep.peek_cur().GetColor();
                    btnColor.BackColor = rep.peek_cur().GetColor();
                    checkStick.Checked = rep.peek_cur().sticky;
                }
                if (e.KeyChar == 120)
                {
                    rep.go_next();
                    colorDialog1.Color = rep.peek_cur().GetColor();
                    btnColor.BackColor = rep.peek_cur().GetColor();
                    checkStick.Checked = rep.peek_cur().sticky;
                }
                tree.Print();
                rep.print2(g);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Shape c = null;

            if (rBtnCircle.Checked)
            {
                c = new Circle(e.X, e.Y, 30, colorDialog1.Color, pictureBox1.Width, pictureBox1.Height);
            }
            if (rBtnPolygon.Checked)
            {
                c = new Polygon(e.X, e.Y, 30, colorDialog1.Color, pictureBox1.Width, pictureBox1.Height, 4);
            }
            if (rBtnStar.Checked)
            {
                c = new Star(e.X, e.Y, 30, colorDialog1.Color, pictureBox1.Width, pictureBox1.Height, 5);
            }
            if (e.Button.ToString() == "Left")
            {
                if (rep.find(c) == -1)
                {
                    rep.push_next(c);
                }
                else
                {
                    colorDialog1.Color = rep.peek_cur().GetColor();
                    btnColor.BackColor = rep.peek_cur().GetColor();
                    checkStick.Checked = rep.peek_cur().sticky;
                }
            }
            else
            {
                if (!rep.pick(c))
                {
                    rep.delete_pick();
                }
            }

            rep.print2(g);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;

                if (rep.getSize() > 0)
                {
                    rep.peek_cur().SetColor(colorDialog1.Color);
                    rep.print2(g);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            while (rep.getSize() != 0)
            {
                rep.delete_pick();
            }

            rep.print2(g);
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (rep.getSize() != 0)
            {
                SGroup group = new SGroup(pictureBox1.Width, pictureBox1.Height);
                rep.toFirst();
                int cnt = 0;
                for (int i = 0; i < rep.getSize(); i++, rep.next()) //считаем количество отмеченных элементов
                    if (rep.isChecked() == true) cnt++;
                if (cnt > 1)
                {
                    rep.toFirst();
                    while (cnt != 0)
                    {
                        if (rep.isChecked() == true)
                        {
                            group.Add(rep.getIterator());
                            rep.pop_iter();
                            cnt--;
                        }
                        else
                        if (rep.getSize() != 0) rep.next();
                    }
                    rep.push_next(group);
                }
                rep.print2(g);
            }
        }

        private void btnUngroup_Click(object sender, EventArgs e)
        {
            if (rep.getSize() != 0 && rep.peek_cur() is SGroup)
            {
                while (((SGroup)rep.peek_cur()).size() != 0)
                {
                    rep.push_next(((SGroup)rep.peek_cur()).Out());
                    rep.go_prev();
                }
                rep.pop_cur();
            }
            rep.print2(g);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                StreamWriter stream = new StreamWriter(f);
                stream.WriteLine(rep.getSize());
                if (rep.getSize() != 0)
                {
                    rep.toFirst();
                    for (int i = 0; i < rep.getSize(); i++, rep.next()) rep.getIterator().Save(stream);
                }
                stream.Close();
                f.Close();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(openFileDialog1.FileName, FileMode.Open);
                StreamReader stream = new StreamReader(f);
                int i = Convert.ToInt32(stream.ReadLine());
                Factory shapeFactory = new ShapeFactory();  //фабрика КОНКРЕТНЫХ объектов
                for (; i > 0; i--)
                {
                    string tmp = stream.ReadLine();
                    rep.push_next(shapeFactory.createShape(tmp));
                    rep.peek_cur().Load(stream);
                }
                stream.Close();
                f.Close();
            }
            rep.print2(g);
            tree.Print();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ((e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse) && e.Node.Text != "Фигуры")
            {
                TreeNode tmp = e.Node;
                while (tmp.Parent.Text != "Shape") tmp = tmp.Parent;
                treeView1.SelectedNode = tmp;
                rep.toFirst();
                rep.setNodeCur();
                for (int i = 0; i < tmp.Index; i++) rep.go_next();
                rep.print2(g);
            }
        }

        private void checkStick_CheckedChanged(object sender, EventArgs e)
        {
            if (rep.getSize() != 0 && !(rep.peek_cur() is SGroup))
            {
                rep.peek_cur().sticky = checkStick.Checked;
                if (checkStick.Checked == true) rep.peek_cur().AddRepos(rep);
            }
        }
    }
}


