using System;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastracture.Identity
{
	public class AppIdentityDbContextSeed
	{
		public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
		{
			if (!userManager.Users.Any())
			{
				var user = new AppUser
				{
					DisplayName = "Bob",
					Email = "Bob@test.com",
					UserName = "Bob@test.com",
					Address = new Address
					{
						FirstName = "Bob",
						LastName = "Bobbety",
						Street = "10 tha street",
						City = "New York",
                        State = "NY",
						ZipCode = "90210"
                    }
				};

				await userManager.CreateAsync(user, "Pa$$w0rd");
			}
		}
	}
}

