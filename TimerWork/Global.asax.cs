using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Timers;
using System.IO;
using System.Threading;
using System.Net;
using System.Text;
using log4net;
using System.Reflection;
using log4net.Config;
using Quartz;
using Quartz.Impl;
using TimerWork.QuartzJobs;
using System.Collections.Specialized;

namespace TimerWork
{
    public class Global : System.Web.HttpApplication
    {
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static int i = 0;
        private IScheduler scheduler = null;

        protected void Application_Start(object sender, EventArgs e)
        {
            //定时器
            System.Timers.Timer myTimer = new System.Timers.Timer(5000);
            myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Enabled = true;
            myTimer.AutoReset = true;

            log.Error(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":Application_Start");

            var props = new NameValueCollection
            {
                { "quartz.scheduler.instanceName", "QuartzDotNetDemo" }
            };
            ISchedulerFactory factory = new StdSchedulerFactory(props);

            //构造调度对象，并创建对应的调度任务
            scheduler = factory.GetScheduler();
            CalendarTask();

            //启动所有的任务
            scheduler.Start();
        }

        private void CalendarTask()
        {
            IJobDetail job = JobBuilder.Create<MyJobs>()
                .WithIdentity("BlogArticleSendJob", "group1")
                .Build();

            //每周星期天凌晨1点实行一次：0 0 1 ? * L
            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                                      .WithIdentity("trigger1", "group1")
                                                      .WithCronSchedule("/3 * * ? * *")//0 0 1 ? * L
                                                      .Build();

            DateTimeOffset ft = scheduler.ScheduleJob(job, trigger);
            log.Error(string.Format("您在 {0} 时候创建了Quartz任务", DateTime.Now));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            //下面的代码是关键，可解决IIS应用程序池自动回收的问题                                                                                                                                                                                                                                                                                                                                                                                                                                                                            解决IIS应用程序池自动回收的问题  


            log.Error(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":Application_End");

            string url = "http://work.77mv.com.cn/index.aspx";

            Thread.Sleep(7000);

            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流  
            }
            catch (Exception ex)
            {
                log.Error("Application_End错误", ex);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流  
            }

        }

        private void myTimer_Elapsed(object source, ElapsedEventArgs e)
        {
            try
            {
                RunTheTask();
            }
            catch (Exception ex)
            {
                log.Error("myTimer_Elapsed错误", ex);
            }
        }

        private void RunTheTask()
        {
            //在这里写你需要执行的任务


            log.Error((i++) + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        }
    }
}