using System;

namespace BoxingParadiseBackend.Models
{
    public class Login
    {
        public int Id { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Key { get; set; }
        public bool IsExpired { get; set; }
    }
}