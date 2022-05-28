using ALSM.UI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.UI.Library.Api
{
    public class OrderEndpoint : IOrderEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public OrderEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task Add(List<MaterialOrderModel> materialOrderModels)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Order/Add", materialOrderModels))
            {
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
