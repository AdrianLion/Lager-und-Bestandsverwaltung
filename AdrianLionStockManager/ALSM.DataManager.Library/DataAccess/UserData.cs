
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
        private readonly SqlDataAccess _sql;

        public UserData(IConfiguration config)
        {
            _config = config;
            _sql = new SqlDataAccess(_config);
        }
        public List<UserModel> GetUserById(string Id)
        {
            

            var p = new { Id = Id };

            var result = _sql.Load<UserModel, dynamic>("dbo.spUser_GetById", p);

            return result;
        }
    }
}
