using System;
namespace Repository
{
	public static class ConnexionsStrings
	{
		public static string DataBaseName = "database-name";

		public static string Local = $"Server=localhost;Database=local_{DataBaseName};Uid=root;";
        public static string Preproduction = $"Server=https://1.1.1.1;Database=pre-production_{DataBaseName};Uid=root; Pws=****;";
        public static string Production = $"Server=https://1.1.1.1;Database=production_{DataBaseName};Uid=root; Pws=****;";
    }
}

