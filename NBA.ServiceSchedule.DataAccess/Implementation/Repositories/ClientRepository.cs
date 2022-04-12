using Dapper;
using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Models.DAOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Repositories
{
    public class ClientRepository
    {
        public async Task<ActionResult<ClientDetailsDao>> GetClientDetails(string clientCode)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $@"
                        select cari_vdaire_no as [{nameof(ClientDetailsDao.TaxNumber)}], 
                        cari_wwwadresi as [{nameof(ClientDetailsDao.ContractNumber)}],
                        cari_EMail as [{nameof(ClientDetailsDao.ContractDate)}], 
                        crg_isim as [{nameof(ClientDetailsDao.GroupName)}], 
                        cari_unvan2 as [{nameof(ClientDetailsDao.Address)}], 
                        '' as [{nameof(ClientDetailsDao.Contact)}], 
                        cari_CepTel as [{nameof(ClientDetailsDao.Email)}] from CARI_HESAPLAR 
                        LEFT JOIN CARI_HESAP_GRUPLARI on cari_grup_kodu = crg_kod where cari_kod = @ClientCode";

                    var dao = (await connection.QueryAsync<ClientDetailsDao>(query, new { ClientCode = clientCode })).FirstOrDefault();

                    return ActionResult<ClientDetailsDao>.Succeed(dao);
                }
            }
            catch (Exception exception)
            {
                return ActionResult<ClientDetailsDao>.Failed(exception);
            }
        }
    }
}
