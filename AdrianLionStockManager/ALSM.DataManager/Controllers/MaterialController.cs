using ALSM.DataManager.Library.DataAccess;
using ALSM.DataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALSM.DataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialData _materialData;

        public MaterialController(IMaterialData materialData)
        {
            _materialData = materialData;
        }
        [HttpGet]
        public List<MaterialModel> Get()
        {
            
            return _materialData.GetMaterials();
        }

        [Route("/api/Material/Update")]
        [HttpPost]
        public void Update(List<MaterialModel> materials)
        {
            _materialData.UpdateDescriptions(materials);
        }
    }
}
