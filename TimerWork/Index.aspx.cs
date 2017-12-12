using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

using System.Reflection;
using log4net;

namespace TimerWork
{
    public partial class Index : System.Web.UI.Page
    {
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {

            log.Error(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            
        }
    }
}