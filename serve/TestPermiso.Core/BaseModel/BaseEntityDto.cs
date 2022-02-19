using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Core.BaseModel
{
    public interface IBaseEntityDto : IBaseDto
    {
        DateTime? DeletedDate { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string DeletedBy { get; set; }
        string UpdatedBy { get; set; }
    }
    public class BaseEntityDto : BaseDto, IBaseEntityDto
    {
        public virtual DateTime? DeletedDate { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string DeletedBy { get; set; }
        public virtual string UpdatedBy { get; set; }
    }
}
