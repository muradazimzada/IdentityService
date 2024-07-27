using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using IdentityService.Domain.Enums;

namespace IdentityService.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DefaultValue(RecordStatus.Active)]
        public RecordStatus RecordStatus { get; set; }

        public Guid? CreatedById { get; set; }


        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        public Guid? UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual User UpdatedBy { get; set; }

        public Guid? DeletedById { get; set; }

        [ForeignKey("DeletedById")]
        public virtual User DeletedBy { get; set; }
    }
}
