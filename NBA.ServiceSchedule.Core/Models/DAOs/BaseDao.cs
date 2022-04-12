using NBA.ServiceSchedule.Core.Models.Entities;
using System;

namespace NBA.ServiceSchedule.Core.Models.DAOs
{
    public abstract class BaseDao
    {
        public BaseDao()
        {
            CreatorUserId = 1;
            CreateDate = DateTime.Today;
        }

        public int Id { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public abstract BaseEntity ToEntity();

        public virtual BaseDao SetBase(BaseEntity entity)
        {
            Id = entity.Id;
            CreatorUserId = entity.CreatorUserId;
            CreateDate = entity.CreateDate;
            IsDeleted = entity.IsDeleted;

            return this;
        }
    }
}
