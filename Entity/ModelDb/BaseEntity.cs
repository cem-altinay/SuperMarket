using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ModelDb
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class BaseUserEntity : BaseEntity
    {
        public int CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
