using System;

namespace LogicLayer.Models
{
    public class TruncatedUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Banned { get; set; }
        public string Image { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Sex { get; set; }
    }
}
