namespace Helpers
{
	public static class PasswordManagement
	{      
        public static string HashPassword(string password)
        {
            if (password is null)
                throw new ArgumentException("password is null");

            if (password == string.Empty)
                throw new ArgumentException("password is empty");

            return Encryptor.Hash(password);
        }

        public static bool Compare(string password1, string password2)
        {
            return HashPassword(password1).Equals(password2);
        }
    }
}