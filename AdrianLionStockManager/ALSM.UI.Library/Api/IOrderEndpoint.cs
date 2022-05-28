using ALSM.UI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALSM.UI.Library.Api
{
    public interface IOrderEndpoint
    {
        Task Add(List<MaterialOrderModel> materialOrderModels);
    }
}