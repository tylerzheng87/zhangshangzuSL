using System;
using Quartz;
using System.Data.SqlClient;

namespace ZSZ.Tests
{
    public class TestJob : IJob
    {
        //execute 执行的时候另开一个线程
        //如果需要复杂执行任务可以写cron
        public void Execute(IJobExecutionContext context)
        {
            try
            {          
            Console.WriteLine("任务执行啦"+DateTime.Now);
            SqlConnection conn = new SqlConnection();
            conn.Open();
            Console.WriteLine("ok");
            Console.ReadKey();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
