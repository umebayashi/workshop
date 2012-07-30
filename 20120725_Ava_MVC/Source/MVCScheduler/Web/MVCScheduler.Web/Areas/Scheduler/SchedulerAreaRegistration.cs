using System.Web.Mvc;

namespace MVCScheduler.Web.Areas.Scheduler
{
	public class SchedulerAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "Scheduler";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"Scheduler_default",
				"Scheduler/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
