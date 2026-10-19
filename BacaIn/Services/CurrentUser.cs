using System;
using BacaIn.Models;

namespace BacaIn.Services
{
    public static class CurrentUser
    {
        public static User? Current { get; set; }

        public static bool IsLoggedIn => Current != null;
        public static bool IsAdmin => Current?.IsAdmin ?? false;
        public static bool IsStudent => Current?.IsStudent ?? false;

        public static void Logout()
        {
            Current = null;
        }
    }
}
