using System;

namespace Pos.Models
{
    public enum UserRole
    {
        Manager,
        Cashier
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string Name { get; set; } = string.Empty;

        public bool IsManager => Role == UserRole.Manager;
    }
} 