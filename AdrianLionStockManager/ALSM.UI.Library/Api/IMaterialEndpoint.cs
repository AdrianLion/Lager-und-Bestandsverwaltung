using ALSM.UI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALSM.UI.Library.Api
{
    public interface IMaterialEndpoint
    {
        Task<List<MaterialModel>> GetAll();
        Task Update(List<MaterialModel> materials);
    }
}