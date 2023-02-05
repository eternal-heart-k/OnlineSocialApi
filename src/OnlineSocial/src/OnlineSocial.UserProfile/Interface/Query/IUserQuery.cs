using OnlineSocial.Foundation;
using OnlineSocial.UserProfile.Model;
using System.Threading.Tasks;

namespace OnlineSocial.UserProfile.Interface.Query
{
    public interface IUserQuery
    {
        Task<UserInfo> GetFirstUserInfoAsync();
    }
}
