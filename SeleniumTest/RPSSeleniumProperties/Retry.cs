using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties
{
    public static class Retry
    {
        public static T Execute<T>(Func<T> Code, TimeSpan maxWaitTime, TimeSpan interval)
        {
            TimeSpan current = new TimeSpan(0, 0, 0);
            while(current<maxWaitTime)
            {
                try
                {
                    return Code();
                }catch 
                {
                    if (current < maxWaitTime)
                    {
                        current += interval;
                        System.Threading.Thread.Sleep(interval);
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return default(T);
        }
        public static T Execute<T>(Func<T> Code, int maxTimes, TimeSpan interval)
        {
            int current = 0;
            while (current < maxTimes)
            {
                try
                {
                    return Code();
                }
                catch
                {
                    if (current < maxTimes)
                    {
                        current += 1;
                        System.Threading.Thread.Sleep(interval);
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return default(T);
        }
        public static void Execute(Action Code, TimeSpan maxWaitTime, TimeSpan interval)
        {
            TimeSpan current = new TimeSpan(0, 0, 0);
            bool done = false;
            while (current < maxWaitTime && !done)
            {
                try
                {
                    Code();
                    done = true;
                }
                catch
                {
                    if (current < maxWaitTime)
                    {
                        current += interval;
                        System.Threading.Thread.Sleep(interval);
                    }
                    else
                    {
                        throw;
                    }
                }

            }
        }
        public static void Execute(Action Code, int maxTimes, TimeSpan interval)
        {
            int current = 0;
            bool done = false;
            while (current < maxTimes && !done)
            {
                try
                {
                    Code();
                    done = true;
                }
                catch
                {
                    if (current < maxTimes)
                    {
                        current += 1;
                        System.Threading.Thread.Sleep(interval);
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            
        }

    }
}
