using System.Threading.Tasks;

namespace NBA.ServiceSchedule.Core.Abstracts.DbContext
{
    public interface ITableObject : IDatabaseObject
    {
        Task<ActionResult> InsertDefaultValues();
    }
}
