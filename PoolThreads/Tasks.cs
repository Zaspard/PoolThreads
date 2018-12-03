using System;
using System.Threading;
using System.Threading.Tasks;

namespace PoolThreads
{
    public class Tasks
    {
        private bool isFirstTaskAdded = false;
        private bool isSecondTaskAdded = false;
        private bool isThirdTaskAdded = false;

        public Task FirstTask()
        {
            if (isFirstTaskAdded)
            {
                return null;
            }
            isFirstTaskAdded = true;
            return new Task(() =>
            {
                Console.WriteLine("Task1 Started");
                Thread.Sleep(5000);
                Console.WriteLine("Task1 Complete");
                isFirstTaskAdded = false;
            });
        }

        public Task SecondTask()
        {
            if (isSecondTaskAdded)
            {
                return null;
            }
            isSecondTaskAdded = true;
            return new Task(() =>
            {
                Console.WriteLine("Task2 Started");
                Thread.Sleep(10000);
                Console.WriteLine("Task2 Complete");
                isSecondTaskAdded = false;
            });
        }

        public Task ThirdTask()
        {
            if (isThirdTaskAdded)
            {
                return null;
            }
            isThirdTaskAdded = true;
            return new Task(() =>
            {
                Console.WriteLine("Task3 Started");
                Thread.Sleep(15000);
                Console.WriteLine("Task3 Complete");
                isThirdTaskAdded = false;
            });
        } 
    }
}
