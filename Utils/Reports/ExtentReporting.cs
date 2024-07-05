using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Reports
{
    public class ExtentReporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        private static ExtentReports StartReporting()
        {
            
            var path = "C: \\Users\\lromero";


            //if (Directory.Exists(path))
            //{
            //    Console.WriteLine(path);
            //    Console.WriteLine("debug")
            //}


            if (extentReports == null)
            {
                Directory.CreateDirectory(path);

                extentReports = new ExtentReports();
                var sparkReporter = new ExtentSparkReporter(path);

                extentReports.AttachReporter(sparkReporter);
            }

            return extentReports;
        }

        public static void CreateTest(string testName)
        {
            extentTest = StartReporting().CreateTest(testName);
        }

        public static void EndReporting()
        {
            StartReporting().Flush();
        }

        public static void LogInfo(String info)
        {
            extentTest.Info(info);
        }

        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }

        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }

        public static void LogScreenshot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }

    }
}
