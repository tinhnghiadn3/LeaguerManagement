﻿namespace LeaguerManagement.Entities.ViewModels
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public double TimezoneOffset { get; set; }
    }
}
