using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolThreads
{
    public class TaskManager
    {
        private ConcurrentQueue<Task> container = new ConcurrentQueue<Task>();

        public void AddCollection(Task task)
        {
            if (task != null)
            {
                container.Enqueue(task);
                Console.WriteLine("Task added");
            }
            else
            {
                Console.WriteLine("But this task already running");
            }
        }

        public void StartTask()
        {
            while (true)
            {
                if (container.Count != 0)
                {
                    container.TryDequeue(out var task);
                    task.Start();
                    task.Wait();
                }
            }
        }
    }
}
