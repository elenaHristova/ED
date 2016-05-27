using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectHack.Models
{
	public class ProjectHackContextInitializer :DropCreateDatabaseIfModelChanges<ProjectHackContext>
	{
		
		protected override void Seed(ProjectHackContext context)
		{
			List<User> users = new List<User>
			{
				new User("elena","123","elena_hristov@abv.bg"),
				new User("pesho","123","pesho_hristov@abv.bg"),
                new User("peti","123","peti_hristova@abv.bg"),
			};

			foreach (var user in users)
			{
				context.Users.Add(user);
			}
			context.SaveChanges();
		}
	}
}