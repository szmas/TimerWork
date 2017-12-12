using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Commom
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = @"start work.77mv.com.cn";
            cmd = "start iexplore.exe www.baidu.com";
            cmd = "start chrome.exe www.baidu.com";
            cmd = "start firefox.exe www.baidu.com";
            cmd = "explorer http://www.baidu.com";

            string output = "";
            CmdHelper.RunCmd(cmd, out output);

            CmdHelper.RunCmd("iexplore", "http://work.77mv.com.cn/");
            CmdHelper.RunCmd2("start", "http://work.77mv.com.cn");

            CmdHelper.OpenWebSite("iexplore", "http://work.77mv.com.cn/");
            CmdHelper.OpenWebSite("chrome", "http://work.77mv.com.cn/");
            CmdHelper.OpenWebSite("firefox", "http://work.77mv.com.cn/");

            

            Console.WriteLine(output);

        }
    }
}
