﻿namespace MakeYourTrip.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }
}
