using OnlineSocial.Foundation;
using OnlineSocial.User.Model;

namespace OnlineSocial.Application.Interface
{
    public interface IUserService
    {
        Task<UserInfo> GetFirstUserInfoAsync();
    }
}
