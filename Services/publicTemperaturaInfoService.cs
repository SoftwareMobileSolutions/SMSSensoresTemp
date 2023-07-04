using mtemp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using mtemp.Models;
using mtemp.Interfaces;
using System.Data;
using Dapper;
using System.Linq;

namespace mtemp.Services
{
    public class publicTemperaturaInfoService: IpublicTemperaturaInfo
    {
        private readonly SqlCnConfigMain _context;
        private readonly SqlCnConfigMainB _context2;
        public publicTemperaturaInfoService(SqlCnConfigMain context, SqlCnConfigMainB context2)
        {
            _context = context;
            _context2 = context2;
        }

        public async Task<(IEnumerable<publicTemperaturaInfoModel.temp_Areas>, IEnumerable<publicTemperaturaInfoModel.temp_TempCoord>, IEnumerable<publicTemperaturaInfoModel.temp_sensors>)> get_ConfigTemperaturaAreaImg(paramsModel p)
        {
            var conn = p.BD == 0 ? _context.CreateConnection() : _context2.CreateConnection();

            IEnumerable<publicTemperaturaInfoModel.temp_Areas> r1;
            IEnumerable<publicTemperaturaInfoModel.temp_TempCoord> r2;
            IEnumerable<publicTemperaturaInfoModel.temp_sensors> r3;

            using (conn)
            {
                string query = @"exec mTemp_obtenerCoordenadasYValores @mobileid";
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var reader = await conn.QueryMultipleAsync(query, new { p.mobileid }, commandType: CommandType.Text);
                r1 = reader.Read<publicTemperaturaInfoModel.temp_Areas>().ToList();
                r2 = reader.Read<publicTemperaturaInfoModel.temp_TempCoord>().ToList();
                r3 = reader.Read<publicTemperaturaInfoModel.temp_sensors>().ToList();

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return (r1, r2, r3);
        }
    }
}
