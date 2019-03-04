using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffer
{
    public class MyQueue
    {
        private Queue<string> _queue;

        public MyQueue()
        {
            _queue = new Queue<string>();
        }

        //public void addInQueue(FileSystemEventArgs e)
        //{
        //    _queue.Enqueue(e.FullPath);
        //}

        public void addInQueue(string fullPath)
        {
            _queue.Enqueue(fullPath);
        }

        public string getFromQueue()
        {
            
                return _queue.Dequeue();
            
        }

        public bool isEmpty()
        {
            if (_queue.Count > 0)
                return false;
            return true;
        }
    }
}
