using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Officer_Project
{
    class Officer
    {
        private Mutex _mutex = new Mutex();
        private int _currentCustomerTimeInside;
        public int Timer { get; set; }
        private int _customersServed = 0;

        public Officer()
        {
            Timer = 0;
        }

        public void CallNextOne(Object i)
        {
            while (QueueManagement.Customers > 0)
            {
                //_mutex.WaitOne();
                if (QueueManagement.Customers > 0)
                {
                    QueueManagement.Customers--;
                    //_mutex.ReleaseMutex();
                    _currentCustomerTimeInside = QueueManagement._random.Next(QueueManagement._timeInside - 5, QueueManagement._timeInside + 5);
                    Thread.Sleep(_currentCustomerTimeInside);
                    Timer += _currentCustomerTimeInside;
                    _customersServed++;
                }
                else
                {
                    //_mutex.ReleaseMutex();
                    break;
                }
            }
            Console.WriteLine("Officer {0} Done!, worked {1} minutes, served {2}",(int) i + 1, Timer, _customersServed);
        }
    }
}
