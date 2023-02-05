using System;

namespace OnlineSocial.UserProfile.Model
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
