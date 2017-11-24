using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7
{
    class AddThread
    {
        Thread thread;

        public AddThread(string pathToFile, string checkWord) {
            thread = new Thread(() => { ReadFile.ReadAction(pathToFile, checkWord); });
            thread.Start();
        }
    }
}
