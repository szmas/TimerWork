using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz.Impl;
using Quartz;
using System.Collections.Specialized;

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个调度器工厂
            var props = new NameValueCollection
            {
                { "quartz.scheduler.instanceName", "QuartzDotNetDemo" }
            };
            ISchedulerFactory factory = new StdSchedulerFactory(props);

            //获取调度器
            IScheduler sched = factory.GetScheduler();
            

            //定义一个任务，关联"HelloJob"
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            //由触发器每40秒触发执行一次任务
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(3)
                    .RepeatForever())
                .Build();

            // 根据规则，生产对应的触发器
            ITrigger trigger2 = TriggerBuilder.Create()
                                        .WithIdentity("myTrigger", "group1")
                                        .StartNow()
                                        .WithCronSchedule("/5 * * ? * *")    //时间表达式，5秒一次     
                                        .Build();

            //加入作业调度池中加入作业调度池中
            sched.ScheduleJob(job, trigger);

            //开始运行
            sched.Start();
        }
    }
}
