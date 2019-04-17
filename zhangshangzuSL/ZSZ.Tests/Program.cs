using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
namespace ZSZ.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(TestJob));
            IMutableTrigger triggerBossReport = CronScheduleBuilder.DailyAtHourAndMinute(10, 12).Build();
            triggerBossReport.Key = new TriggerKey("triggerTest");
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            sched.Start();
        }
    }
}
