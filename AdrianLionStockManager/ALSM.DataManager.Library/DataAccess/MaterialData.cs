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
    public class MaterialData : IMaterialData
    {
        private readonly IConfiguration _config;
        private readonly SqlDataAccess _sql;

        public MaterialData(IConfiguration config)
        {
            _config = config;
            _sql = new SqlDataAccess(_config);
        }

        public List<MaterialModel> GetMaterials()
        {
            return _sql.Load<MaterialModel, dynamic>("dbo.spMaterial_GetAll", new { });
        }
    }
}
