using ALSM.DataManager.Library.Models;
using System.Collections.Generic;

namespace ALSM.DataManager.Library.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUserById(string Id);
    }
}