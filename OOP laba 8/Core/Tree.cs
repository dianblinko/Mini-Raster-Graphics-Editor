using System.Windows.Forms;

namespace OOP_laba_8.Core
{
    class Tree : Observer
    {
        private Repository repository;
        private TreeView tree;

        public Tree(Repository repository, TreeView tree)
        {
            this.repository = repository;
            this.tree = tree;
        }

        public void Print()
        {
            tree.Nodes.Clear();

            if (repository.getSize() != 0)
            {
                int SelectedIndex = 0;
                TreeNode start = new TreeNode("Shape");
                repository.toFirst();
                for (int i = 0; i < repository.getSize(); i++, repository.next())
                {
                    if (repository.getNodeCur() == repository.getNodeIterator()) SelectedIndex = i;
                    PrintNode(start, repository.getIterator());
                }
                tree.Nodes.Add(start);
                tree.SelectedNode = tree.Nodes[0].Nodes[SelectedIndex];
            }

            tree.ExpandAll();
        }

        private void PrintNode(TreeNode node, Shape shape)
        {
            if (shape is SGroup)
            {
                TreeNode tn = new TreeNode(shape.GetInfo());
                if (((SGroup)shape).repository.getSize() != 0)
                {
                    ((SGroup)shape).repository.toFirst();
                    for (int i = 0; i < ((SGroup)shape).repository.getSize(); i++, ((SGroup)shape).repository.next())
                    {
                        PrintNode(tn, ((SGroup)shape).repository.getIterator());
                    }
                }

                node.Nodes.Add(tn);
            }
            else
            {
                node.Nodes.Add(shape.GetInfo());
            }
        }

        public override void SubjectChanged()
        {
            Print();
        }
    }
}
