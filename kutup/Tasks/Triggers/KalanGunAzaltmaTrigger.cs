using Quartz;
using Quartz.Impl;

namespace kutup.Tasks.Triggers
{
    public class KalanGunAzaltmaTrigger
    {
        public static void Baslat()
        {
            IScheduler zamanlayici = StdSchedulerFactory.GetDefaultScheduler().Result;
            if (!zamanlayici.IsStarted)
            {
                zamanlayici.Start();
            }
            IJobDetail gorev=JobBuilder.Create<KalanGunAzaltmaJob>().Build();
            ICronTrigger tetikleyici = (ICronTrigger)TriggerBuilder.Create()
            .WithIdentity("KalanGunAzaltmaJobs","null")
            .WithCronSchedule("* * * * * ? *")
            .Build();
            zamanlayici.ScheduleJob(gorev,tetikleyici);
        }
    }
}
