using System;
namespace Practice8
{
    public class MyStack<T>
    {
        private List<T> _data = new List<T>();

        public void Push(T item)
        {
            _data.Add(item);
        }

        public T Pop(int el)
        {
            if (_data.Count == 0)
            {
               Console.WriteLine("Элемент пуст.");
            }

            T item = _data[el];
            _data.RemoveAt(el);
            return item;
        }

        public T Peek()
        {
            if (_data.Count == 0)
            {
                Console.WriteLine("Элемент пуст.");
            }

            return _data[_data.Count - 1];
        }

        public int Count
        {
            get
            {
                return _data.Count;
            }
        }
    }

}

