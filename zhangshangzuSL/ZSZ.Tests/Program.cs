using System;
using MyIBll;
using Autofac;
using System.Reflection;

namespace ZSZ.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(TestJob));
            IMutableTrigger triggerBossReport = CronScheduleBuilder.DailyAtHourAndMinute(10, 12).Build();
            triggerBossReport.Key = new TriggerKey("triggerTest");
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            sched.Start();
            */
            //IUserBll bll = new UserBll();彻底的不用这种方式来创建
            //UserBll bll = new UserBll();
            //bll.AddNew("aa", "234");

            ContainerBuilder builder = new ContainerBuilder();
            //把UserBll注册IUserBll的实现类
            //builder.RegisterType<UserBll>().As<IUserBll>();
            //如果程序中类很多每个都注册一遍太麻烦，用Assembly
            //builder.RegisterType<UserBll>().AsImplementedInterfaces();
            //builder.RegisterType<DogBll>().AsImplementedInterfaces();

            Assembly asm =  Assembly.Load("MyBllImpl");
            builder.RegisterAssemblyTypes(asm).AsImplementedInterfaces();
            IContainer container = builder.Build();
            //建议最好配置成无状态的（实现类中不要有成员变量）,使用单例方式
            //整片代码没有在体现userdll，dogdll这些类了只有被Autofac创建出来的对象才会被“属性自动注入”
            //创建IuserBll实现类的对象
            //如果resolve()抛异常或者返回null,说明没有解析到实现类。如果有多个实现类，resolver.Resolve<ISerive1>()只会返回其中的一个累的对象

            //如果想返回多个实现类的对象，改成resolve.resolve<IEnuerable<Iservice>>() 然后foreach一下即可。
            /*
               class Person
               { 
                    public int Age
                   { get; set; }
               public void A()
               {
                   Age++;
               }

               }
           Person p = new Person();p1.A()你掉了一下
               p1.A();//2我调了一下两个互相干扰
           class Person
           {
               public int Age
               { get; set; }
               public void A()
               {
                   //无状态对象，使用单利方式最好，整个系统就一个对象降低了内存的占用，SingleInstance
                   //即使有变量也是局部变量赋值，即使你屌我调大家调也是局部变量的赋值也不会相呼影响
                   Console.WriteLine("aaa");
                   int i = 5;
                   i++;
               }

           }
           */
            IUserBll bll = container.Resolve<IUserBll>();
            bll.AddNew("aa", "23");

            IDogBll dogBll = container.Resolve<IDogBll>();
            dogBll.Bark();
            Console.WriteLine("Ok");
            Console.ReadKey();

        }
    }
}
