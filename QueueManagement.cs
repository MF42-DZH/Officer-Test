using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Officer_Project
{
    class QueueManagement
    {
        private static int _customers;
        public static int Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _mutex.WaitOne();
                _customers = value;
                _mutex.ReleaseMutex();
            }
        }
        private static Mutex _mutex = new Mutex();
        public static int _timeInside;
        private int _officers;

        public QueueManagement(int customers, int timeInside, int officers)
        {
            _customers = customers;
            _timeInside = timeInside;
            _officers = officers;
        }

    }
}
