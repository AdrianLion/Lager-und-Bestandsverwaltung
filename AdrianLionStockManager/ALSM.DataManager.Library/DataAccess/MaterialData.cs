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

        public void AddMaterial(MaterialModel material)
        {
            dynamic p = new
            {
                Name = material.Name,
                Description = material.Description,
            };
            _sql.Save("dbo.spMaterial_Insert", p);
        }

        public List<MaterialModel> GetMaterials()
        {
            return _sql.Load<MaterialModel, dynamic>("dbo.spMaterial_GetAll", new { });
        }
        public void UpdateDescriptions(List<MaterialModel> materials)
        {
            foreach (var item in materials)
            {
                dynamic p = new
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    QuantityInStock = item.QuantityInStock,
                    CreatedDate = item.CreatedDate
                };
                _sql.Save("dbo.spMaterial_Update", p);
            }

        }
    }
}
