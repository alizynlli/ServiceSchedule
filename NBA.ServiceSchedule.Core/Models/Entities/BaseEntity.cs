using NBA.ServiceSchedule.Core.Global;
using NBA.ServiceSchedule.Core.Models.DAOs;
using System;

namespace NBA.ServiceSchedule.Core.Models.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatorUserId = Session.CurrentUser?.Id ?? 0;
        }

        public int Id { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public abstract BaseDao ToDao();

        public virtual BaseEntity SetBase(BaseDao dao)
        {
            Id = dao.Id;
            CreatorUserId = dao.CreatorUserId;
            CreateDate = dao.CreateDate;
            IsDeleted = dao.IsDeleted;

            return this;
        }
    }
}
