using OnlineSocial.Application.Interface;
using OnlineSocial.Foundation;
using OnlineSocial.UserProfile.Interface.Query;
using OnlineSocial.UserProfile.Model;

namespace OnlineSocial.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserQuery _userQuery;
        public UserService(IUserQuery userQuery) 
        {
            _userQuery = userQuery;
        }

        public async Task<UserInfo> GetFirstUserInfoAsync()
        {
            var queryable = await _userQuery.GetFirstUserInfoAsync();
            if (queryable == null)
            {
                throw new Exception("暂无用户");
            }
            return queryable;
        }
    }
}
