using ALSM.DataManager.Library.Models;
using System.Collections.Generic;

namespace ALSM.DataManager.Library.DataAccess
{
    public interface IMaterialData
    {
        List<MaterialModel> GetMaterials();
        void UpdateDescriptions(List<MaterialModel> materials);
        void AddMaterial(MaterialModel material);
    }
}