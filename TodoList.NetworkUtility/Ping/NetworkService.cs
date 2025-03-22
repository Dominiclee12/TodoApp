using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.NetworkUtility.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            return "Ping Sent";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
    }
}
