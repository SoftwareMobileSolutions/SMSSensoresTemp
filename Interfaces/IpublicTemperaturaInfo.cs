using mtemp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mtemp.Interfaces
{
    public interface IpublicTemperaturaInfo
    {
        public Task<(IEnumerable<publicTemperaturaInfoModel.temp_Areas>, IEnumerable<publicTemperaturaInfoModel.temp_TempCoord>, IEnumerable<publicTemperaturaInfoModel.temp_sensors>)> get_ConfigTemperaturaAreaImg(paramsModel p);
    }
}
