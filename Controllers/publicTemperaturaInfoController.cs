using Microsoft.AspNetCore.Mvc;
using mtemp.Interfaces;
using mtemp.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

namespace mtemp.Controllers
{
    public class publicTemperaturaInfoController : Controller
    {
        private IpublicTemperaturaInfo _IpublicTemperaturaInfo;
        public publicTemperaturaInfoController(IpublicTemperaturaInfo IpublicTemperaturaInfo_) {
            _IpublicTemperaturaInfo = IpublicTemperaturaInfo_;
        }

        public async Task<IActionResult> publicTemperaturaInfo()
        {
            return await Task.Run(() =>
            {
                return PartialView();
            });
        }

        [HttpGet]
        public async Task<JsonResult> getConfiguracionAreaImg(paramsModel p)
        {
            var data = await _IpublicTemperaturaInfo.get_ConfigTemperaturaAreaImg(p);
            return await Task.Run(() =>
            {
                return Json(new { 
                    areas = data.Item1, 
                    coord = data.Item2, 
                    sensores = data.Item3  
                });
            });

        }
    }
}
