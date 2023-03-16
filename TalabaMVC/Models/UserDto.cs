﻿namespace TalabaMVC.Models
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Username { get; set; }
        public string[] Roles { get; set; }
        public string Region { get; set; }
        public string Token { get; set; }
    }
}
