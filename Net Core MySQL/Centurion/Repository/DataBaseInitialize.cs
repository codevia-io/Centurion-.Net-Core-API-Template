using Entities;

namespace Repository
{
	public class DataBaseInitialize
	{
		private UserRepository UserRepository;

		public DataBaseInitialize()
		{
			UserRepository = new UserRepository();

			try
			{
				User? user = UserRepository.Find(1);
			}
			catch (Exception)
			{
				DefaultsUsers();
			}
        }

		private void DefaultsUsers()
		{
			User user1 = new User()
			{
				FirsName = "José Miguel",
				LastName = "Ramos",
				Email = "j.ramos@codevia.io",
				Telephone = 078987654,
				UserName = "j.ramos",
				Password = Helpers.PasswordManagement.HashPassword("admin"),
				permision = Enums.UserPermission.Admin
			};

			UserRepository.Created(user1);
        }
	}
}

