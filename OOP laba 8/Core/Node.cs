namespace OOP_laba_8.Core
{
    public unsafe class Node
    {
        private Node prev, next;
        protected unsafe Shape c;
        bool pick = false;

        public Node()//конструктор по умолчанию
        {
            prev = null;
            next = null;
        }

        public Node go_next()//возвращает указатель на следующий элемент
        {
            return next;
        }

        public Node go_prev()//возвращает указатель на предыдущий элемент
        {
            return prev;
        }

        public void set_next(Node next)//устнавливает указатель на следующий  элемент
        {
            this.next = next;
        }

        public void set_prev(Node prev)//устанавливает указатель на предыдуший элемент
        {
            this.prev = prev;
        }

        public Shape get_c()//возвращает объект
        {
            return c;
        }

        public void set_c(Shape c)//устанавливает объект
        {
            this.c = c;
        }

        public void change_pick()
        {
            if (pick)
                pick = false;
            else
                pick = true;
        }

        public bool get_pick()
        {
            return pick;
        }
    }
}
