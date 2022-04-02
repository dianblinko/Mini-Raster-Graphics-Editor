using System.Drawing;

namespace OOP_laba_8.Core
{
    public class Repository : Observed
    {
        protected Node cur, front, back, iterator;
        protected int size;

        public int getSize()
        {
            return size;
        }
        public Repository()
        {
            size = 0;
            cur = null;
            front = null;
            back = null;
        }
        public Node begin()
        {
            return front;
        }
        public Node end()
        {
            return back;
        }
        public void pop_cur()
        {
            Node tmp = cur;
            if (size > 1)
            {
                if (cur == front)
                {
                    front = cur.go_next();
                    cur = cur.go_next();
                    cur.set_prev(null);

                }
                else
                {
                    if (cur == back)
                    {
                        back = cur.go_prev();
                        back.set_next(null);
                        cur = cur.go_prev();
                    }
                    else
                    {
                        Node next = cur.go_next();
                        Node prev = cur.go_prev();
                        cur = cur.go_prev();
                        next.set_prev(prev);
                        prev.set_next(next);
                    }
                }  
            }
            else
            {
                cur = null;
                front = null;
                back = null;
            }

            size--;
            Notify();
        }
        public Shape peek_cur()
        {
            Node tmp = cur;
            return tmp.get_c();
        }
        public void push_back(Shape c)
        {
            Node nd = new Node();
            nd.set_c(c);
            nd.set_next(null);
            nd.set_prev(back);
            if (back != null)
            {
                back.set_next(nd);
            }
            if (size == 0)
            {
                front = nd;
                back = nd;
                cur = front;
            }
            else
            {
                back = nd;
            }
            size++;

            Notify();
        }

        public void pop_back()
        {
            Node tmp = back;
            size--;
            back = back.go_prev();
            tmp = null;
        }

        public void push_prev(Shape c)
        {
            Node tmp = new Node();
            tmp.set_c(c);
            if (cur == front)
            {
                front = tmp;
                cur.set_prev(tmp);
                tmp.set_next(cur);
                cur = cur.go_prev();
            }
            else
            {
                Node prev = cur.go_prev();
                prev.set_next(tmp);
                tmp.set_prev(prev);
                tmp.set_next(cur);
                cur.set_prev(tmp);
                cur = cur.go_prev();
            }
            size++;
        }

        public void push_next(Shape c)
        {
            if (size == 0)
            {
                push_back(c);
                return;
            }

            Node tmp = new Node();
            tmp.set_c(c);

            if (cur == back)
            {
                cur.set_next(tmp);
                back = tmp;
                tmp.set_prev(cur);
                cur = cur.go_next();
            }
            else
            {
                Node next = cur.go_next();
                cur.set_next(tmp);
                tmp.set_prev(cur);
                tmp.set_next(next);
                next.set_prev(tmp);
                cur = cur.go_next();
            }

            size++;
            Notify();
        }

        public void go_next()
        {
            if (cur == back)
                cur = front;
            else
                cur = cur.go_next();

            Notify();
        }

        public void go_prev()
        {
            if (cur == front)
            {
                cur = back;
            }
            else cur = cur.go_prev();

            Notify();
        }
        public void print2(Graphics g)
        {
            g.Clear(Color.White);
            if (size > 0)
            {
                Node tmp = front;
                while (tmp != back)
                {
                    if (tmp == cur)
                    {
                        if (tmp.get_pick())
                            tmp.get_c().DrawRec(g, new Pen(Color.Blue, 1));
                        else
                            tmp.get_c().DrawRec(g, new Pen(Color.Red, 1));
                    }
                    else
                        if (tmp.get_pick())
                        tmp.get_c().DrawRec(g, new Pen(Color.Green, 1));
                    tmp.get_c().Draw(g);

                    tmp = tmp.go_next();

                }

                if (tmp == cur)
                {
                    if (tmp.get_pick())
                        tmp.get_c().DrawRec(g, new Pen(Color.Blue, 1));
                    else
                        tmp.get_c().DrawRec(g, new Pen(Color.Red, 1));
                }
                else
                {
                    if (tmp.get_pick())
                        tmp.get_c().DrawRec(g, new Pen(Color.Green, 1));
                }
                        
                tmp.get_c().Draw(g);
                Notify();
            }
        }


        public int find(Shape c)
        {
            if (size > 0)
            {
                Node tmp = front;
                int i = 0;
                while (tmp != back)
                {
                    if (tmp.get_c().Find(c))
                    {
                        cur = tmp;
                        return i;
                    }
                    i++;
                    tmp = tmp.go_next();
                }
                if (tmp.get_c().Find(c))
                {
                    cur = tmp;
                    return i;
                }
            }
            return -1;

        }

        public bool pick(Shape c)
        {
            if (size > 0)
            {
                Node tmp = front;
                while (tmp != back)
                {
                    if (tmp.get_c().Find(c))
                    {
                        tmp.change_pick();
                        return true;
                    }

                    tmp = tmp.go_next();
                }

                if (tmp.get_c().Find(c))
                {
                    tmp.change_pick();
                    return true;
                }
            }

            return false;
        }

        public void delete_pick()
        {
            if (size > 0)
            {
                Node tmp = front;
                bool del = true;
                while (tmp != back)
                {
                    if (size > 1)
                    {
                        if (tmp.get_pick())
                        {
                            del = false;
                            if (tmp == front)
                            {
                                front = tmp.go_next();
                                if (tmp == cur)
                                {
                                    cur = cur.go_next();
                                    cur.set_prev(null);
                                }
                            }
                            else
                            {
                                if (tmp == cur)
                                    cur = cur.go_prev();
                                Node next = tmp.go_next();
                                Node prev = tmp.go_prev();
                                next.set_prev(prev);
                                prev.set_next(next);
                            }
                            if (front == tmp)
                                tmp.go_next().set_prev(null);
                            tmp = tmp.go_next();
                            size--;
                        }
                        else
                        {
                            tmp = tmp.go_next();
                        }
                    }
                    else
                    {
                        if (tmp.get_pick())
                        {
                            size--;
                            front = null;
                            back = null;
                            cur = null;
                            return;
                        }
                    }
                }
                if (tmp == back)
                {
                    if (tmp.get_pick())
                    {
                        if (size > 1)
                        {
                            back = tmp.go_prev();
                            tmp.go_prev().set_next(null);
                            if (cur == tmp) cur = cur.go_prev();
                            size--;
                            return;
                        }
                        else
                        {
                            size--;
                            front = null;
                            back = null;
                            cur = null;
                            return;
                        }
                    }
                }
                if (del)
                {
                    pop_cur();
                }

            }
        }

        public void toFirst()
        {
            iterator = front;
        }

        public void next()
        {
            iterator = iterator.go_next();
        }

        public void pop_iter()
        {
            Node tmp = iterator;
            if (size > 1)
            {
                if (iterator == front)
                {
                    front = iterator.go_next();
                    if (iterator == cur)
                        cur = cur.go_next();
                    iterator = iterator.go_next();
                    iterator.set_prev(null);

                }
                else
                {
                    if (iterator == back)
                    {
                        if (iterator == cur)
                            cur = cur.go_prev();
                        back = iterator.go_prev();
                        back.set_next(null);
                        iterator = iterator.go_prev();

                    }
                    else
                    {
                        if (tmp == cur)
                            cur = cur.go_next();
                        Node next = iterator.go_next();
                        Node prev = iterator.go_prev();
                        iterator = iterator.go_next();
                        next.set_prev(prev);
                        prev.set_next(next);
                    }
                }
            }
            else
            {
                iterator = null;
                front = null;
                back = null;
                cur = null;
            }

            size--;
        }

        public Shape getIterator()
        {
            return (iterator.get_c());
        }

        public bool isChecked()
        {
            if (iterator.get_pick()) 
                return true;
            else 
                return false;
        }
        ~Repository()
        {
            Node cur = back;
            while (cur != front)
            {
                Node tmp = cur;
                cur = tmp.go_prev();
            }
        }

        public Node getNodeIterator()
        {
            return iterator;
        }

        public Node getNodeCur()
        {
            return cur;
        }

        public void setNodeCur()
        {
            cur = iterator;
            Notify();
        }
    }
}
