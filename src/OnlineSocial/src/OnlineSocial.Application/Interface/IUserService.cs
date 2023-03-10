using OnlineSocial.Foundation;
using OnlineSocial.UserProfile.Model;

namespace OnlineSocial.Application.Interface
{
    public interface IUserService
    {
        Task<UserInfo> GetFirstUserInfoAsync();
    }
}
