﻿namespace MvcClient.Controllers
{
    public class SignOutViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public bool  SignedOut { get; set; }
    }
}