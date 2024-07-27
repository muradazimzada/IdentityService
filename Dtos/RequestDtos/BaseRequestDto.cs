namespace IdentityService.Dtos.RequestDtos
{
    public record class BaseRequestDto
    {
        public Guid? CreatedById { get; private set; }
        public Guid? UpdatedById { get; private set; }
        public Guid? DeletedById { get; private set; }

        //internal void SetAuditInfo(Guid? createdById=null, Guid? updatedById, Guid? deletedById)
        //{
        //    CreatedById = createdById;
        //    UpdatedById = updatedById;
        //    DeletedById = deletedById;
        //}

        internal void SetCreatedBy(Guid createdById)
        {
            CreatedById = createdById;
        }

        internal void SetUpdatedBy(Guid createdById)
        {
            UpdatedById = createdById;
        }

        internal void SetDeletedBy(Guid createdById)
        {
            DeletedById = createdById;
        }
    }
}
