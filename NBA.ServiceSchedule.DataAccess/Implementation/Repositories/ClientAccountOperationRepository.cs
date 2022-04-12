using Dapper;
using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule.DataAccess.Implementation.Repositories
{
    public class ClientAccountOperationRepository
    {
        public Task<ActionResult> InsertAsync(ClientAccountOperationDao dao)
        {
            return Task.Run(() =>
            {
                using (var con = SqlHelper.CreateConnection())
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        dao.cha_fileid = 51;
                        dao.cha_create_user = 1;
                        dao.cha_create_date = DateTime.Now;
                        dao.cha_lastup_user = 1;
                        dao.cha_lastup_date = DateTime.Now;
                        dao.cha_evrak_tip = 63;
                        dao.cha_cinsi = 8;
                        dao.cha_d_cins = 0;
                        dao.cha_cari_cins = 0;
                        dao.cha_d_kur = 1;
                        dao.cha_altd_kur = 1;
                        dao.cha_karsid_kur = 1;
                        dao.cha_kasa_hizmet = 3;
                        //dao.cha_vergipntr = 1;

                        con.Execute("[ss]._sp_CARI_HESAP_HAREKETLERI_Insert", dao, transaction, null, CommandType.StoredProcedure);

                        transaction.Commit();
                        return ActionResult.Succeed();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return ActionResult.Failed(e);
                    }
                }
            });
        }

        public Task<ActionResult> InsertDescriptionAsync(DocumentDescriptionDao dao)
        {
            return Task.Run(() =>
            {
                using (var con = SqlHelper.CreateConnection())
                {
                    try
                    {
                        con.Execute("_sp_EVRAK_ACIKLAMALARI_Insert", dao, null, null, CommandType.StoredProcedure);

                        return ActionResult.Succeed();
                    }
                    catch (Exception e)
                    {
                        return ActionResult.Failed(e);
                    }
                }
            });
        }

        public async Task<ActionResult<List<string>>> GetClientsWithInvoices(DateTime lastDate, List<string> clientCodeList, string series)
        {
            try
            {
                using (var con = SqlHelper.CreateConnection())
                {
                    var firstDate = new DateTime(lastDate.Year, lastDate.Month, 1);

                    var query = $@" select distinct cha_kod from CARI_HESAP_HAREKETLERI where cha_tip = 0 and cha_cinsi = 8 and cha_evrak_tip = 63 and cha_kasa_hizmet = 3 and
                                    cha_tarihi between @FirstDate and @LastDate and cha_evrakno_seri = '{series}' and
                                    cha_kod in ('{string.Join("', '", clientCodeList)}')";

                    var selectedClientCodeList = (await con.QueryAsync<string>(query, new { FirstDate = firstDate, LastDate = lastDate })).ToList();

                    return ActionResult<List<string>>.Succeed(selectedClientCodeList);
                }
            }
            catch (Exception e)
            {
                return ActionResult<List<string>>.Failed(e);
            }
        }

        public async Task<decimal> GetOldAmount(DateTime lastDate, string clientCode, string series)
        {
                using (var con = SqlHelper.CreateConnection())
                {
                    var firstDate = new DateTime(lastDate.Year, lastDate.Month, 1);

                    var query = $@" select sum(cha_aratoplam) from CARI_HESAP_HAREKETLERI where cha_tip = 0 and cha_cinsi = 8 and cha_evrak_tip = 63 and cha_kasa_hizmet = 3 and
                                    cha_tarihi between @FirstDate and @LastDate and cha_evrakno_seri = '{series}' and
                                    cha_kod = @ClientCode";

                    var amount = await con.ExecuteScalarAsync<decimal>(query, new { FirstDate = firstDate, LastDate = lastDate, ClientCode = clientCode});

                    return amount;
                }
        }

        public async Task<ActionResult<int>> GetNewNumberBySeries(string series)
        {
            try
            {
                using (var con = SqlHelper.CreateConnection())
                {
                    var query = $"SELECT ISNULL(MAX(cha_evrakno_sira), 0) FROM CARI_HESAP_HAREKETLERI WITH (NOLOCK, INDEX=NDX_CARI_HESAP_HAREKETLERI_04) WHERE (cha_evrak_tip=63) AND  (cha_evrakno_seri=@Series)";
                    var parameters = new { Series = series };
                    var number = await con.ExecuteScalarAsync<int>(query, parameters);
                    return ActionResult<int>.Succeed(number + 1);
                }
            }
            catch (Exception e)
            {
                return ActionResult<int>.Failed(e);
            }
        }
    }
}
