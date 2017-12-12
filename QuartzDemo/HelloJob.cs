using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;

namespace QuartzDemo
{
    class HelloJob:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("当前时间："+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
