namespace NBA.ServiceSchedule.Core.Abstracts.DbContext
{
    public interface IDatabaseObject
    {
        string Name { get; }
        string GetCreateQuery();
        string DropQuery { get; }
    }
}
