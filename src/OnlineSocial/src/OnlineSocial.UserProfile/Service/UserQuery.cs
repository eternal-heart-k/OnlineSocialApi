using Microsoft.EntityFrameworkCore;
using OnlineSocial.Foundation;
using OnlineSocial.UserProfile.Infrastructure.DbContexts;
using OnlineSocial.UserProfile.Interface.Query;
using OnlineSocial.UserProfile.Model;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSocial.UserProfile.Service
{
    public class UserQuery : IUserQuery
    {
        private readonly IDbContextFactory<UserDbContext> _userDbContext;

        public UserQuery(IDbContextFactory<UserDbContext> userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<UserInfo> GetFirstUserInfoAsync()
        {
            await using var dbContext = await _userDbContext.CreateDbContextAsync();
            return dbContext.UserInfos.FirstOrDefault();
        }
    }
}
