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
        // private Mutex _mutex = new Mutex();
        private int _currentCustomerTimeInside;
        public int Timer { get; set; }
        private int _customersServed = 0;

        public Officer()
        {
            Timer = 0;
        }

        public void CallNextOne(Object i)
        {
            // Attempt to use QueueManagement's static Mutex instance.
            // int customers = -1;   // Attempt to use local variable as checking storage.

            // Replace with do/while for checking after reassignment
            do
            {
                if (QueueManagement._mutex.WaitOne())  // This if makes sure the code is executed only when the Mutex is acquired by the Officer instance
                {
                   // customers = QueueManagement.Customers;

                    // DEBUG LINE: Console.WriteLine(String.Format("Mutex in QueueManagement acquired by Officer {0}, current customer count is {1}", (int)i + 1, customers));

                    if (QueueManagement.Customers > 0)
                    {
                        QueueManagement.Customers--;
                        QueueManagement._mutex.ReleaseMutex();
                        _currentCustomerTimeInside = QueueManagement._random.Next(QueueManagement._timeInside - 5, QueueManagement._timeInside + 5);
                        Thread.Sleep(_currentCustomerTimeInside);
                        Timer += _currentCustomerTimeInside;
                        _customersServed++;
                    }
                    else
                    {
                        QueueManagement._mutex.ReleaseMutex();
                        break;
                    }
                }
                // DEBUG ELSE PATH
                // else
                // {
                //     Console.WriteLine(String.Format("Mutex in QueueManagement not acquired by Officer {0}", (int)i + 1));
                // }
            } while (QueueManagement.Customers > 0);
            Console.WriteLine("Officer {0} Done!, worked {1} minutes, served {2}, {3} are now in the line",(int) i + 1, Timer, _customersServed, QueueManagement.Customers);
        }
    }
}
