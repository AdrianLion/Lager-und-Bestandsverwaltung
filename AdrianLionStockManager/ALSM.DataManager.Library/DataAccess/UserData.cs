
using ALSM.DataManager.Library.Internal.DataAccess;
using ALSM.DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.DataManager.Library.DataAccess
{
    public class UserData : IUserData
    {
        private readonly IConfiguration _config;

        public UserData(IConfiguration config)
        {
            _config = config;
        }
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var p = new { Id = Id };

            var result = sql.Load<UserModel, dynamic>("dbo.spUser_GetById", p);

            return result;
        }
    }
}
