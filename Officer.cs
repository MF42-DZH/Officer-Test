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
        private Random _random = new Random();
        private int _currentCustomerTimeInside;
        private int _timer = 0;
        private QueueManagement _queue;

        public Officer(QueueManagement Queue)
        {
            _queue = Queue;
        }

        public void CallNextOne(Object i)
        {
            while (QueueManagement.Customers > 0 && _timer < 540)
            {
                if (QueueManagement.Customers > 0)
                {
                    QueueManagement.Customers--;
                    _currentCustomerTimeInside = _random.Next(QueueManagement._timeInside - 5, QueueManagement._timeInside + 5);
                    Thread.Sleep(_currentCustomerTimeInside);
                    _timer += _currentCustomerTimeInside;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Officer {0} Done!, worked {1} minutes",(int) i + 1, _timer);
        }
    }
}
