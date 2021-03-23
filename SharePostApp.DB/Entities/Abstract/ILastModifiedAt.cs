using System;

namespace SharePostApp.DB.Entities.Abstract
{
    public interface ILastModifiedAt
    {
        public DateTime? LastModifiedAt { get; set; }
    }
}
