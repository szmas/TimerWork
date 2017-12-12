using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Common.Logging;
using System.Reflection;

namespace TimerWork.QuartzJobs
{
    public class MyJobs : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region IJob 成员

        public void Execute(IJobExecutionContext context)
        {
            _logger.Error("TestJob测试:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        #endregion
    }
}