﻿using System;
namespace Models.Forms
{
	public class Login
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}

    public class LoginAccesInfo
    {
        public string UserName { get; set; }
        public string Tokent { get; set; }
        public string Message { get; set; }
    }
}

